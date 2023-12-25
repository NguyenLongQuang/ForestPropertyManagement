using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestPropertyManagement.ViewModels
{

    internal class Base<T> where T : new()
    {
        List<T> all;
        public List<T> List
        {
            get
            {
                if (all == null)
                {
                    all = new Provider().Select<T>("SELECT * FROM " + typeof(T).Name);
                }
                return all;
            }
        }

        public T Selected { get; set; }
        public int SelectedIndex
        {
            get => all == null ? -1 : all.IndexOf(Selected);
            set => Selected = all == null ? new T() : all[value];
        }

        public event EventHandler OnChanged;
        protected void RaiseOnChanged()
        {
            OnChanged?.Invoke(this, EventArgs.Empty);
        }
        public void Remove()
        {
            List.Remove(Selected);
            RaiseOnChanged();
        }
    }
}
