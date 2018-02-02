using AegisImplicitMail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace smtptest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMailUse();
        }
        public  void SendMailUse()
        {
            string host = textBox3.Text;// 邮件服务器smtp.163.com表示网易邮箱服务器    
            string userName = textBox1.Text;// 发送端账号   
            string password = textBox2.Text;// 发送端密码(这个客户端重置后的密码)




            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式    
            client.Host = host;//邮件服务器
            client.UseDefaultCredentials = true;
            client.Port = Convert.ToInt32(textBox4.Text);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(userName, password);//用户名、密码
            client.Timeout = 5000;
            
            //////////////////////////////////////
            string strfrom = userName;
            string strto = textBox5.Text;
        


            string subject = "这是测试邮件标题5";//邮件的主题             
            string body = "测试邮件内容5";//发送的邮件正文  

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress(strfrom, "xyf");
            msg.To.Add(strto);
            msg.Subject = subject;//邮件标题   
            msg.Body = body;//邮件内容   
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码   
            msg.IsBodyHtml = true;//是否是HTML邮件   
            msg.Priority = MailPriority.High;//邮件优先级   
            object userState = msg;


            try
            {
                client.Send(msg);
                //client.SendAsync(msg, null);
                System.Windows.Forms.MessageBox.Show("发送成功");
                //Console.WriteLine("发送成功");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                System.Windows.Forms.MessageBox.Show("发送失败");
                //Console.WriteLine(ex.Message, "发送邮件出错");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendAim();
        }
        private void SendAim()
        {
            //Generate Message
            var mailMessage = new MimeMailMessage();
            mailMessage.From = new MimeMailAddress(textBox1.Text);
            mailMessage.To.Add(textBox5.Text);
            mailMessage.Subject = "环都测试邮件";
            mailMessage.Body = "环都测试邮件";

            //Create Smtp Client
            var mailer = new MimeMailer(textBox3.Text, Convert.ToInt32(textBox4.Text));
            mailer.User = textBox1.Text;
            mailer.Password = textBox2.Text;
            mailer.SslType = SslMode.Ssl;
            mailer.AuthenticationMode = AuthenticationType.Base64;

            //Set a delegate function for call back
            //mailer.SendCompleted += compEvent;
            //mailer.SendMailAsync(mailMessage);
            try
            {
                mailer.Send(mailMessage);
                //client.SendAsync(msg, null);
                System.Windows.Forms.MessageBox.Show("发送成功");
                //Console.WriteLine("发送成功");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                System.Windows.Forms.MessageBox.Show("发送失败");
                //Console.WriteLine(ex.Message, "发送邮件出错");
            }
            
            
        }
    }
}
