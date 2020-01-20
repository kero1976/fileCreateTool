using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace テスト用ファイル大量作成ツール
{
    
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<SizeUnit> _sizeUnit = new ObservableCollection<SizeUnit>();
        private ObservableCollection<SizeUnit> _childSizeUnit = new ObservableCollection<SizeUnit>();

        private bool createFile = false;
        private bool createDir = false;
        private bool createDirFile = false;
        public MainWindow()
        {
            InitializeComponent();
            _sizeUnit.Add(new SizeUnit { Id = 1, Name = "byte", Size = 1 });
            _sizeUnit.Add(new SizeUnit { Id = 2, Name = "Kbyte", Size = 1024 });
            _sizeUnit.Add(new SizeUnit { Id = 3, Name = "Mbyte", Size = 1024 * 1024 });
            _sizeUnit.Add(new SizeUnit { Id = 4, Name = "Gbyte", Size = 1024 * 1024 * 1024 });

            _childSizeUnit.Add(new SizeUnit { Id = 1, Name = "byte", Size = 1 });
            _childSizeUnit.Add(new SizeUnit { Id = 2, Name = "Kbyte", Size = 1024 });
            _childSizeUnit.Add(new SizeUnit { Id = 3, Name = "Mbyte", Size = 1024 * 1024 });
            _childSizeUnit.Add(new SizeUnit { Id = 4, Name = "Gbyte", Size = 1024 * 1024 * 1024 });

            SizeUnitCombo.ItemsSource = _sizeUnit;
            childSizeUnitCombo.ItemsSource = _childSizeUnit;
        }

        private void fileCheck_Checked(object sender, RoutedEventArgs e)
        {
            fileStack.IsEnabled = true;
            createFile = true;
        }

        private void fileCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            fileStack.IsEnabled = false;
            createFile = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (createFile)
            {
                
                //MessageBox.Show($"fileNameI:{fileNameI.Text},varI:{varI.Text},fixI{fixI.IsChecked},size:{fileSize.Text},Unit:{SizeUnitCombo.Text}");
                bool result = Logic.createFileVarI(baseDir.Text, fileNameI.Text, int.Parse(varI.Text), (bool)fixI.IsChecked, long.Parse(fileSize.Text));
                if (result)
                {
                    MessageBox.Show("ファイルを作成しました");
                }
                else
                {
                    MessageBox.Show("ファイルの作成に失敗しました");
                }
            }
            if (createDir)
            {
                MessageBox.Show($"fileNameI:{dirName.Text},varI:{varJ.Text},fixI{fixJ.IsChecked}");
                bool result = Logic.createDirVarJ(baseDir.Text, dirName.Text, int.Parse(varJ.Text), (bool)fixJ.IsChecked);
                if (result)
                {
                    MessageBox.Show("フォルダを作成しました");
                }
                else
                {
                    MessageBox.Show("Fileフォルダの作成に失敗しました");
                }
            }
        }

        private void dirCheck_Checked(object sender, RoutedEventArgs e)
        {
            dirStack.IsEnabled = true;
            createDir = true;
        }

        private void dirCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            dirStack.IsEnabled = false;
            createDir = false;
        }
    }
}
