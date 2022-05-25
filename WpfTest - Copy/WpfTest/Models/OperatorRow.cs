using System.Collections.Generic;

namespace WpfTest
{
    public class OperatorRow : ObservableObject
    {
        public List<OperatorField> fields = new();


        private bool used;
        private string displayField = string.Empty;

        public string DisplayField { get => displayField; set { displayField = value; OnPropertyChanged(); } }

        public bool Used { get => used; set { used = value; OnPropertyChanged(); } }


        public void Reset()
        {
            Used = false;
            DisplayField = string.Empty ;
        }
    }
}
