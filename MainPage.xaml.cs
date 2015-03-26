using AppGerenciaSenhas.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AppGerenciaSenhas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Criptografia objCripto = new Criptografia();
            byte[] cifra = System.Text.UTF8Encoding.UTF8.GetBytes(txtCifra.Text);
            byte[] t = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            if(rdbAES.IsChecked.Value){
                objCripto.Encripta(Security.Algoritmo.AES, t, cifra);
            }else if(rdbDES.IsChecked.Value){
                objCripto.Encripta(Security.Algoritmo.SHA1, t, cifra);
            }
            else if(rdbMD5.IsChecked.Value)
            {
                objCripto.Encripta(Security.Algoritmo.MD5, t, cifra);
            }
        }

        private void btnValidar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ValidaSenha));
        }
    }
}
