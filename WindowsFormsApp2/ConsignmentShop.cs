using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ConsignmentShop : Form
    {
        private Store store = new Store();
        private List<Item> shoppingCartData = new List<Item>();
        private decimal storeProfit = 0;

        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorsBinding = new BindingSource();

        public ConsignmentShop()
        {

            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items.Where( x => x.Sold == false).ToList();
            itemsListbox.DataSource = itemsBinding;

            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListbox.DataSource = cartBinding;

            shoppingCartListbox.DisplayMember = "Display";
            shoppingCartListbox.ValueMember = "Display";

            vendorsBinding.DataSource = store.Vendors;
            vendorListbox.DataSource = vendorsBinding;

            vendorListbox.DisplayMember = "Display";
            vendorListbox.ValueMember = "Display";

        }

        private void SetupData()
        {
            store.Vendors.Add(new Vendor { FirstName = "Dragos", LastName = "Nedelcu" });
            store.Vendors.Add(new Vendor { FirstName = "Madalina", LastName = "Chituta", Commision = .7 });

            store.Items.Add(new Item
            {
                Title = "Coca cola",
                Description = "Not so natura juice",
                Price = 4.80M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "Natural juice",
                Description = "Freshly squized lemons and oranges",
                Price = 5.50M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "Milk",
                Description = "From well grown cows",
                Price = 2.50M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Sink",
                Description = "Luxury made with diamond",
                Price = 520M,
                Owner = store.Vendors[1]
            });

            store.Name = "Luxor";
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            // Figure out what we selected in the list
            // Copy to the shoping cart

            Item selectedItem = (Item)itemsListbox.SelectedItem;
            shoppingCartData.Add(selectedItem);
            cartBinding.ResetBindings(false);
        }

        private void makePurhase_Click(object sender, EventArgs e)
        {
            // Mark each item in the cart as sold
            // Clear the cart

            foreach (var item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commision * item.Price;
                storeProfit += ( 1 - (decimal)item.Owner.Commision ) * item.Price;
            }

            shoppingCartData.Clear();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();

            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorsBinding.ResetBindings(false);
            storeProfitValue.Text = string.Format("$ {0}", storeProfit);

        }

        private void headerText_Click(object sender, EventArgs e)
        {

        }

        private void storeProfitValue_Click(object sender, EventArgs e)
        {

        }
    }
}
