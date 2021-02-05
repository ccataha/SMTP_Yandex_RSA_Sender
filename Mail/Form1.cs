using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using MailKit.Net.Imap;
using MailKit;
using MimeKit;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Mail
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			MailAddress fromAdress = new MailAddress(textBox1.Text, textBox17.Text);
			MailAddress toAdress = new MailAddress(textBox2.Text, textBox1.Text); //receive
			MailMessage message = new MailMessage(fromAdress, toAdress);
			//message.Body = textBox16.Text;
			message.Subject = textBox15.Text; //message
			string password = textBox3.Text;
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Host = "smtp.yandex.ru";
			smtpClient.Port = 587; //465 2525 25 smth 
			smtpClient.EnableSsl = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(fromAdress.Address, password); // sender account credentials

			if (string.IsNullOrEmpty(textBox8.Text))
			{
				message.Body = textBox16.Text;
				smtpClient.Send(message);
			}
			else
			{
				message.Body = textBox8.Text;
				smtpClient.Send(message);
			}
			ToSent(fromAdress.Address, password, message);
			MessageBox.Show("Successful sending!", "Success!");

		}
	   
		private void ToSent(string login, string password, MailMessage message)
		{
				ImapClient imap = new ImapClient();                                                                        
				imap.Connect("imap.yandex.ru", 993, true);  // imap server address 
				imap.Authenticate(login, password);                                                                 
				FolderNamespace folderNamespaceSent = new FolderNamespace('/', "Отправленные"); // getter sent folder 
				IMailFolder folderSent = imap.GetFolder(folderNamespaceSent);
				folderSent.Open(FolderAccess.ReadOnly);
				MimeMessage mimeMessage = (MimeMessage)message;                                                                      
				folderSent.Append(mimeMessage);// add to sent folder
		}
		private void button2_Click(object sender, EventArgs e)
		{
			RSA rsa = new RSA(textBox16.Text, int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox7.Text));
			textBox11.Text = rsa.GetPublicKey();
			textBox12.Text = rsa.GetPrivateKey();
			textBox13.Text = rsa.Encrypt();
			textBox14.Text = rsa.Decrypt();
			textBox15.Text = textBox15.Text;
			textBox8.Text = textBox13.Text + "ENCRYPTEDw/RSA-----BEGIN PUBLIC KEY-----" + textBox11.Text + "-----END PUBLIC KEY-----";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form2 examp = new Form2();
			examp.Show();

		}
	}

	class RSA

	{
		string message, encryptedMessage, decryptedMessage;
		public int p { get; }
		public int q { get; }
		public int d { get; }
		public int k { get; }
		public int n { get; }
		public int phi { get; }
		public int e { get; }


		public RSA(string message, int p, int q, int d, int k)
		{
			this.message = message;
			this.p = p;
			this.q = q;
			this.d = d;
			this.k = k;


			n = p * q;
			phi = (p - 1) * (q - 1);
			e = (phi * k + 1) / d;
		}


		public string GetPublicKey() { return e + " " + n; }
		public string GetPrivateKey() { return d + " " + n; }


		public string Encrypt()
		{
			foreach (var ch in message)
			{
				if (ch == ' ') continue;
				int charIndex = Alphabet.GetCharIndex33(ch);
				var res = BigInteger.ModPow(charIndex, e, n);
				encryptedMessage += res + " ";
			}


			return encryptedMessage;
		}


		public string Decrypt()
		{
			foreach (var ch in encryptedMessage.Trim().Split(' '))
			{
				var res = BigInteger.ModPow(int.Parse(ch), d, n);
				decryptedMessage += Alphabet.GetChar33((int)res);
			}


			return decryptedMessage;
		}


	}
}


