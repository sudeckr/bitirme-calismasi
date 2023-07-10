using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace TrafoMerkeziKontrol
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "***********************",
            BasePath = "**************************"
        };
        IFirebaseClient client;
        public Form1()
        {
           
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
            }

            while (true)
            {
                FirebaseResponse response = await client.GetAsync("acmakapama");
                AcmaKapama acmakapama = response.ResultAs<AcmaKapama>();
                if (acmakapama.acmakapama == 1)
                {
                    pictureBox1.Image = Image.FromFile(@"D:\open.png");
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"D:\close.png");
                }
                await Task.Delay(1000); // Değerleri 1 saniyede bir kontrol etmek için


                FirebaseResponse response2 = await client.GetAsync("acmakapama2");
                AcmaKapama2 acmakapama2 = response2.ResultAs<AcmaKapama2>();
                if (acmakapama2.acmakapama2 == 1)
                {
                    pictureBox2.Image = Image.FromFile(@"D:\open.png");
                }
                else
                {
                    pictureBox2.Image = Image.FromFile(@"D:\close.png");
                }
                await Task.Delay(1000); // Değerleri 1 saniyede bir kontrol etmek için

            }

        }

        private async void button1_Click(object sender, EventArgs e)//manuel
        {
            button1.BackColor = Color.Green;
            button2.BackColor = Color.Red;
            var manuelotomatik = new ManuelOtomatik();
            manuelotomatik.manuelotomatik = 1;
            FirebaseResponse response = await client.UpdateAsync("manuelotomatik", manuelotomatik);
            

        }

        private async void button2_Click(object sender, EventArgs e)//otomatik
        {
            button1.BackColor = Color.Red;
            button2.BackColor = Color.Green;
            var manuelotomatik = new ManuelOtomatik();
            manuelotomatik.manuelotomatik = 0;
            FirebaseResponse response = await client.UpdateAsync("manuelotomatik", manuelotomatik);
           
        }
        private async void button3_Click(object sender, EventArgs e)//grup1acma
        {
            var acmakapama = new AcmaKapama();
            acmakapama.acmakapama = 1;
            FirebaseResponse response = await client.UpdateAsync("acmakapama", acmakapama);

            AcmaKapama result = response.ResultAs<AcmaKapama>();
            pictureBox1.Image = Image.FromFile(@"D:\open.png");
        }

        private async void button4_Click(object sender, EventArgs e)//grup1kapama
        {
            var acmakapama = new AcmaKapama();
            acmakapama.acmakapama = 0;
            FirebaseResponse response = await client.UpdateAsync("acmakapama", acmakapama);
            AcmaKapama result = response.ResultAs<AcmaKapama>();
            pictureBox1.Image = Image.FromFile(@"D:\close.png");
        }
        private async void button5_Click(object sender, EventArgs e)//grup2acma
        {
            var acmakapama2 = new AcmaKapama2();
            acmakapama2.acmakapama2 = 1;
            FirebaseResponse response = await client.UpdateAsync("acmakapama2", acmakapama2);
            AcmaKapama2 result=response.ResultAs<AcmaKapama2>();
            pictureBox2.Image = Image.FromFile(@"D:\open.png");

        }

        private async void button6_Click(object sender, EventArgs e)//grup2kapama
        {
            var acmakapama2 = new AcmaKapama2();
            acmakapama2.acmakapama2 = 0;
            FirebaseResponse response = await client.UpdateAsync("acmakapama2", acmakapama2);
            AcmaKapama2 result = response.ResultAs<AcmaKapama2>();
            pictureBox2.Image = Image.FromFile(@"D:\close.png");
        }
    }
}
