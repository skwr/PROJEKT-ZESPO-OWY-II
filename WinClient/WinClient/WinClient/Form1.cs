using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using Quobject.SocketIoClientDotNet.Client;
using System.Net;

namespace WinClient
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

            socketIoMenager();  //inicjalizacja polaczenia z serverem; docelowo wywolywac po wybraniu NICKU, dodac obsluge braku polaczenia z serverem
        }

        private void socketIoMenager()
        {
            var socket = IO.Socket("http://localhost:3000");    //laczenie z serverem

            
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                //wywolywane w momencie nawiazania polaczenia
                MessageBox.Show("connect");
            });



            socket.On("newMessage", (data) =>
            {
                //wywolywane w momencie rozsylania przez server eventu 'newMessage'
                OnGetMessage(data.ToString());  //wywolanie funkcji odpowiedzialnej za reakcje na nowa wiadomosc
            });
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessage(textBox1.Text);     //po nacisnieciu przycisku wywolanie funkcji wysylajacej do servera wiadomosc za pomoca  'POST'
        }

        private void SendMessage(string _message)
        {
            string postData = "text=" + _message;   //stworzenie tresci przekazywanej za pomoca 'POST'
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);    //konwersja tresci na tablice bitową

            Uri target = new Uri("http://localhost:3000/sendMessage");  //okreslenie adresu POST; docelowo dorobic mozliwosc recznego ustawiania podstawowego czlonu adresu

            WebRequest request = WebRequest.Create(target);     //tworzenie obiektu żądania;
            request.Method = "POST";    //konfiguracja żądania
            request.ContentType = "application/x-www-form-urlencoded";  //konfiguracja żądania

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);   //przesłanie żądania do servera
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                //odpowiedz servera
            }
        }

        private void OnGetMessage(string _message)
        {
            //jest wywolywane w momencie otrzymania wiadomosci
            MessageBox.Show(_message);
        }
    }
}
