using System.Windows;

namespace TextEncrypter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public interface IEncryptor
    {

        string Decrypt(string text);
        string Encrypt(string text);

    }

    public partial class MainWindow : Window
    {
        IEncryptor encryptor;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptClicked(object sender, RoutedEventArgs e)
        {
            encryptTextBox.Text = encryptor.Encrypt(decryptTextBox.Text);

        }

        private void DecryptClicked(object sender, RoutedEventArgs e)
        {
            decryptTextBox.Text = encryptor.Decrypt(encryptTextBox.Text);
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender == reverseRadioButton)
            {
                encryptor = new ReverseEncryptor();
            }
            else if (sender == shiftOneRadioButton)
            {
                encryptor = new ShiftOneEncryptor();
            }
            else if (sender == reverseAlphabetRadioButton)
            {
                encryptor = new ReverseAlphabetEncryptor();
            }
        }
    }
}