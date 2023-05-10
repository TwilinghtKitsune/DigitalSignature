using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace DigitalSignature
{
    public partial class Form1 : Form
    {
        private PublicKey publicKey;
        private DSAParameters signature;

        public class Signature
        {
            public int Counter { get; set; }
            public byte[] G { get; set; }
            public byte[] J { get; set; }
            public byte[] P { get; set; }
            public byte[] Q { get; set; }
            public byte[] Seed { get; set; }
            public byte[] X { get; set; }
            public byte[] Y { get; set; }

            public Signature(DSAParameters sharedParameters)
            {
                Counter = sharedParameters.Counter;
                G = sharedParameters.G;
                J = sharedParameters.J;
                P = sharedParameters.P;
                Q = sharedParameters.Q;
                Seed = sharedParameters.Seed;
                X = sharedParameters.X;
                Y = sharedParameters.Y;
            }


            public Signature(int counter, byte[] g, byte[] j, byte[] p, byte[] q, byte[] seed, byte[] x, byte[] y)
            {
                Counter = counter;
                G = g;
                J = j;
                P = p;
                Q = q;
                Seed = seed;
                X = x;
                Y = y;
            }

            public Signature()
            {
            }
        }

        public class PublicKey
        {


            public byte[] signedHash { get; set; }

            public PublicKey(byte[] signedHash)
            {
                this.signedHash = signedHash;
            }

            public PublicKey()
            {
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Uploading_key_Click(object sender, EventArgs e)
        {
            if (Url_key.Text.Equals(""))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Files (*.key)|*.key;|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string json = Encoding.UTF32.GetString(File.ReadAllBytes(openFileDialog.FileName));
                    publicKey = Newtonsoft.Json.JsonConvert.DeserializeObject<PublicKey>(json);
                    Url_key.Text = "Ключ загружен (" + openFileDialog.FileName + ")";
                }
            }
            else
            {
                string json = Encoding.UTF32.GetString(File.ReadAllBytes(Url_key.Text));
                publicKey = JsonSerializer.Deserialize<PublicKey>(json);
            }
        }

        private void Uploading_message_Click(object sender, EventArgs e)
        {
            if (Url_message.Text.Equals(""))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Files (*.txt)|*.txt;|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        text_message.Text = reader.ReadToEnd();
                    }
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader(Url_message.Text))
                {
                    text_message.Text = reader.ReadToEnd();
                }
            }
        }

        private void Signed_Click(object sender, EventArgs e)
        {
            if (!text_message.Text.Equals(""))
            {
                using SHA1 alg = SHA1.Create();

                byte[] data = Encoding.UTF32.GetBytes(text_message.Text);
                byte[] hash = alg.ComputeHash(data);

                DSAParameters sharedParameters;
                byte[] signedHash;


                using (DSA dsa = DSA.Create())
                {
                    sharedParameters = dsa.ExportParameters(false);
                    signature = signature;

                    DSASignatureFormatter dsaFormatter = new(dsa);
                    dsaFormatter.SetHashAlgorithm(nameof(SHA1));

                    signedHash = dsaFormatter.CreateSignature(hash);
                }

                PublicKey pk = new PublicKey(signedHash);
                string json = JsonSerializer.Serialize(pk);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.key)|*.key|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.DefaultExt = "key";
                saveFileDialog.FileName = "PublicKey.key";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, Encoding.UTF32.GetBytes(json));
                }
            }

        }

        private void Check_Click(object sender, EventArgs e)
        {
            using SHA1 alg = SHA1.Create();

            byte[] data = Encoding.UTF32.GetBytes(text_message.Text);
            byte[] hash = alg.ComputeHash(data);

            using (DSA dsa = DSA.Create())
            {
                dsa.ImportParameters(signature);

                DSASignatureDeformatter dsaDeformatter = new(dsa);
                dsaDeformatter.SetHashAlgorithm(nameof(SHA1));

                if (dsaDeformatter.VerifySignature(hash, publicKey.signedHash))
                {
                    MessageBox.Show("Валидация пройдена.");
                }
                else
                {
                    MessageBox.Show("Валидация не пройдена.");
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "Message.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(text_message.Text);
                }
            }
        }

        private void New_Sign_Click(object sender, EventArgs e)
        {
            using SHA1 alg = SHA1.Create();

            DSAParameters sharedParameters;


            using (DSA dsa = DSA.Create())
            {
                sharedParameters = dsa.ExportParameters(false);
            }

            Signature sign = new Signature(sharedParameters);
            string json = JsonSerializer.Serialize(sign);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "txt files (*.sign)|*.sign|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "sign";
            saveFileDialog.FileName = "Signature.sign";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, Encoding.UTF32.GetBytes(json));
            }

        }

        private void Uploading_sign_Click(object sender, EventArgs e)
        {
            Signature sign = new Signature();
            if (Url_key.Text.Equals(""))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Files (*.sign)|*.sign;|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string json = Encoding.UTF32.GetString(File.ReadAllBytes(openFileDialog.FileName));
                    sign = Newtonsoft.Json.JsonConvert.DeserializeObject<Signature>(json);
                    Url_sign.Text = "Подпись загружена (" + openFileDialog.FileName + ")";
                }
            }
            else
            {
                string json = Encoding.UTF32.GetString(File.ReadAllBytes(Url_key.Text));
                sign = JsonSerializer.Deserialize<Signature>(json);
            }

            if (sign.Counter != null)
            {
                signature.Counter = sign.Counter;
                signature.G = sign.G;
                signature.J = sign.J;
                signature.P = sign.P;
                signature.Q = sign.Q;
                signature.Seed = sign.Seed;
                signature.X = sign.X;
                signature.Y = sign.Y;
            }
        }
    }
}