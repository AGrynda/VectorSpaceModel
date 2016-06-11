using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataHandler;
using Similarity;
using VectorSpaceModel;
using VectorSpaceModel.InverseDocumentFrequency;
using VectorSpaceModel.TermFrequency;
using VectorSpaceModel.TF_IDF.Schemes;
using RichTextBox = System.Windows.Controls.RichTextBox;

namespace FeatureVectorBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string samplesPath = "E:\\gryndos\\Diploma\\diplomlyat\\Samples";
        
        public MainWindow()
        {
            InitializeComponent();
            PathLabel.Content = " Default samples";
            TFSelector.ItemsSource = Enum.GetValues(typeof(TfWeight));
            IDFSelector.ItemsSource = Enum.GetValues(typeof(IdfWeight));
            SimSelector.ItemsSource = Enum.GetValues(typeof(SimilarityMethod));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                samplesPath = dialog.SelectedPath;
                PathLabel.Content = samplesPath;
            }
        }

        private void ReadTermsButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Document.Blocks.Clear();
            var corpus = FileHandler.GetCorpusByPath(samplesPath);

            foreach (var term in corpus.Terms)
            {
                OutputTextBox.AppendText(term + "\n");

            }

            //var terms = corpus.Terms.Aggregate("", (current, term) => current + (term + "\n"));

            //OutputBlock.Text = terms;
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var tfFactory = new TFFactory();
            var idfFactory = new IDFFactory();
            //var scheme = new CustomizedScheme();

            //var simMethod = SimSelector.

            var tf = tfFactory.GetCalculator((TfWeight) TFSelector.SelectedIndex);
            var idf = idfFactory.GetCalculator((IdfWeight) IDFSelector.SelectedIndex);
            //idf.CalculateIdf();
        }
    }
}
