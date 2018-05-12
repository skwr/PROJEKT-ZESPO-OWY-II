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
using System.Web;

namespace WinClient
{
   


    public partial class Form1 : Form
    {
        //komentarz na potrzeby testu git commit

        string myNickName = "";

        Socket socket;

        MessagesBox messagesBox;

        LoginForm loginForm;

        public Form1()
        {
            InitializeComponent();  //inicjalizacja komponentow

            
            
            
            Width = 400;    //tymczasowe ustawienie stalej szerokosci okna
            Height = Screen.PrimaryScreen.WorkingArea.Height;   //ustawienie wysokosci okna w zaleznosci od wielkosci ekranu komputera

            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - Width / 2, 0);    //ustawienie okna programu na srodku ekranu

            
            messagesBox = new MessagesBox(mainPanel);   //stworzenie instancji obiektu wyswietlajacego kolejne wiadomosci

            try
            {
                socket = IO.Socket("http://localhost:3000");    //laczenie z serverem
            }
            catch
            {

                //nie dziala to do konca dobrze
                MessageBox.Show("Błąd przy próbie połączenia z serverem!");

                Application.Exit();
                
                return;
            }



            socketIoMenager();  //inicjalizacja polaczenia z serverem; docelowo wywolywac po wybraniu NICKU, dodac obsluge braku polaczenia z serverem

            Show();
            Enabled = false;
            loginForm = new LoginForm();
            loginForm.loginButton.Click += new EventHandler(Login_Clicked);
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

        private void Login_Clicked(object sender, EventArgs e)
        {
            if (loginForm.nickNameTextBox.Text != String.Empty)
            {
                myNickName = loginForm.nickNameTextBox.Text;
                loginForm.Dispose();
                socket.Emit("login", myNickName);
                Enabled = true;
                Focus();
            }
            else
            {
                MessageBox.Show("Aby zalogować się, musisz podać nick");
            }

        }

        
    }
}
