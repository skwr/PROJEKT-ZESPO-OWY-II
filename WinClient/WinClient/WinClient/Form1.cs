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
        //komentarz na potrzeby testu git commit

        Socket socket = IO.Socket("http://localhost:3000");    //laczenie z serverem

        MessagesBox messagesBox;

        public Form1()
        {
            InitializeComponent();  //inicjalizacja komponentow
            Width = 400;    //tymczasowe ustawienie stalej szerokosci okna
            Height = Screen.PrimaryScreen.WorkingArea.Height;   //ustawienie wysokosci okna w zaleznosci od wielkosci ekranu komputera

            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - Width / 2, 0);    //ustawienie okna programu na srodku ekranu

            messagesBox = new MessagesBox(mainPanel);   //stworzenie instancji obiektu wyswietlajacego kolejne wiadomosci

            socketIoMenager();  //inicjalizacja polaczenia z serverem; docelowo wywolywac po wybraniu NICKU, dodac obsluge braku polaczenia z serverem
        }

        private void socketIoMenager()
        {
            

            
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                //wywolywane w momencie nawiazania polaczenia
                //MessageBox.Show("connected");
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
            socket.Emit("clientMessage", _message);

            
        }

        private void OnGetMessage(string _message)
        {
            //jest wywolywane w momencie otrzymania wiadomosci


            //messagesBox.AddMessage(_message);


            if (InvokeRequired)
                Invoke(messagesBox.NM, _message, messagesBox);
            else
            {
                
            }
        }
    }
}
