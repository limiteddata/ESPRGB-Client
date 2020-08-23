using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using ESPRGB_Client;

namespace WindowsFormsApp2
{
    public partial class scheduleList : UserControl
    {
        public event EventHandler SelectChanged;
        public event EventHandler OrderChanged;
        protected virtual void OnSelectChanged()
        {
            SelectChanged?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnOrderChanged()
        {
            OrderChanged?.Invoke(this, EventArgs.Empty);
        }
        public JArray Items = new JArray();
        public JObject selectedItem;
        public int selectIndex 
        {
            get { return _selectIndex; }
            set
            {
                if(_selectIndex != value)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl.TabIndex == value + 10)
                        {
                            selectedItem = (JObject)Items[value];
                            ctrl.BackColor = Color.FromArgb(52, 152, 219);
                        }
                        else ctrl.BackColor = Color.FromArgb(27, 42, 71);
                    }
                    _selectIndex = value;
                    OnSelectChanged();                   
                }
            }
        }
        private int _selectIndex = -1;

    public scheduleList()
        {
            InitializeComponent();
        }
        public void addItem(JObject t)
        {
            if(!Items.Contains(t)) Items.Add(t);
        }
        public void createAllItems()
        {
            this.Controls.Clear();
            int _y = 15;
            
            for (int i = 0; i < Items.Count(); i++)
            {
                createItem((string)Items[i]["appName"], (string)Items[i]["animName"], 20, _y, 10 + i, (bool)Items[i]["enabled"]);
                _y += 55;
            }
            selectIndex = -1;
        }
        private void createItem(string _appName,string _animationName,int x,int y, int index, bool switchBool)
        {
            this.SuspendLayout();

            Zeroit.Framework.Metro.ZeroitMetroSwitch enableSwitch = new Zeroit.Framework.Metro.ZeroitMetroSwitch();
            enableSwitch.BackColor = Color.Transparent;
            enableSwitch.BackgroundImageLayout = ImageLayout.None;
            enableSwitch.BorderColor = Color.FromArgb(98, 98, 98);
            enableSwitch.CheckColor = Color.FromArgb(98, 98, 98);
            enableSwitch.DefaultColor = Color.FromArgb(6, 215, 156);
            enableSwitch.Font = new Font("Segoe UI", 9F);
            enableSwitch.HoverColor = Color.FromArgb(6, 215, 156);
            enableSwitch.Location = new Point(380, 10);
            enableSwitch.Name = "enableSwitch";
            enableSwitch.Size = new Size(40, 20);
            enableSwitch.SwitchColor = Color.White;
            enableSwitch.Text = "enableSwitch";
            enableSwitch.TabIndex = index;
            enableSwitch.Checked = switchBool;
            enableSwitch.CheckedChanged += (sender, e) => {
                int i = enableSwitch.TabIndex - 10;
                Items[i]["enabled"] = enableSwitch.Checked;
                OnOrderChanged();
            };

            Label animationName = new Label();
            animationName.AutoSize = true;
            animationName.Font = new Font("Segoe UI", 9F);
            animationName.ForeColor = Color.White;
            animationName.Location = new Point(114, 23);
            animationName.Margin = new Padding(0);
            animationName.Name = "animationName";
            animationName.Size = new Size(109, 15);
            animationName.TabIndex = 4;
            animationName.Text = _animationName;
            animationName.TabIndex = index;

            Label appName = new Label();
            appName.AutoSize = true;
            appName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            appName.ForeColor = Color.White;
            appName.Location = new Point(114, 4);
            appName.Margin = new Padding(0);
            appName.Name = "appName";
            appName.Size = new Size(75, 17);
            appName.Text = _appName;
            appName.TabIndex = index;

            Button upButton = new Button();
            upButton.BackColor = Color.FromArgb(6, 215, 156);
            upButton.FlatAppearance.BorderSize = 0;
            upButton.FlatStyle = FlatStyle.Flat;
            upButton.ForeColor = Color.White;
            upButton.Location = new Point(17, 0);
            upButton.Margin = new Padding(0);
            upButton.Name = "upButton";
            upButton.Size = new Size(50, 20);
            upButton.Text = "▲";
            upButton.UseVisualStyleBackColor = false;
            upButton.TabIndex = index;
            upButton.Click += new EventHandler((sender, e) => {
                int i = upButton.TabIndex - 10;
                if (i != 0)
                {
                    var item = Items[i];
                    Items.RemoveAt(i);
                    Items.Insert(i - 1, item);
                    createAllItems();
                    OnOrderChanged();
                }
            });

            Button downButton = new Button();
            downButton.BackColor = Color.FromArgb(46, 46, 54);
            downButton.FlatAppearance.BorderSize = 0;
            downButton.FlatStyle = FlatStyle.Flat;
            downButton.ForeColor = Color.White;
            downButton.Location = new Point(17, 20);
            downButton.Margin = new Padding(0);
            downButton.Name = "downButton";
            downButton.Size = new Size(50, 20);
            downButton.Text = "▼";
            downButton.UseVisualStyleBackColor = false;
            downButton.TabIndex = index;
            downButton.Click += new EventHandler((sender, e) => {
                int i = downButton.TabIndex - 10;          
                if(i < Items.Count-1)
                {
                    var item = Items[i];
                    Items.RemoveAt(i);
                    Items.Insert(i + 1, item);
                    createAllItems();
                    OnOrderChanged();
                }
            });

            Button removeButton = new Button();
            removeButton.BackColor = Color.FromArgb(244, 67, 54);
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.ForeColor = Color.White;
            removeButton.Location = new Point(0, 0);
            removeButton.Margin = new Padding(0);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(17, 40);
            removeButton.Text = "❌";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.TabIndex = index;
            removeButton.Click += new EventHandler((sender, e) => {
                Items.RemoveAt(removeButton.TabIndex-10);
                createAllItems();
                OnOrderChanged();
            });

            Button editButton = new Button();
            editButton.BackColor = Color.FromArgb(98, 98, 98);
            editButton.FlatAppearance.BorderSize = 0;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.ForeColor = Color.White;
            editButton.Location = new Point(67, 0);
            editButton.Margin = new Padding(0);
            editButton.Name = "editButton";
            editButton.Size = new Size(15, 40);
            editButton.Text = "⛭";
            editButton.UseVisualStyleBackColor = false;
            editButton.TabIndex = index;
            editButton.Click += new EventHandler((sender, e) => {
                int selectedIndex = editButton.TabIndex - 10;
                var editItems = new JArray(Items);
                editItems.RemoveAt(selectedIndex);
                var addWindow = new addnewProcess(editItems, (JObject)Items[selectedIndex]["parameters"]);
                addWindow.StartPosition = FormStartPosition.CenterParent;
                if (!addWindow.procList.Items.Contains((string)Items[selectedIndex]["appName"]))
                {
                    addWindow.procList.Items.Add((string)Items[selectedIndex]["appName"]);
                }
                addWindow.procList.SelectedItem = (string)Items[selectedIndex]["appName"];
                addWindow.animList.SelectedItem = (string)Items[selectedIndex]["animName"];
                var res = addWindow.ShowDialog();    
                if (res == DialogResult.OK)
                {
                    Items[selectedIndex] = addWindow.result;
                    createAllItems();
                }
                OnOrderChanged();
            });

            Panel itemPannel = new Panel();
            itemPannel.Controls.Add(editButton);
            itemPannel.Controls.Add(removeButton);
            itemPannel.Controls.Add(upButton);
            itemPannel.Controls.Add(downButton);
            itemPannel.Controls.Add(appName);
            itemPannel.Controls.Add(animationName); 
            itemPannel.Controls.Add(enableSwitch);
            itemPannel.Location = new Point(x, y);
            itemPannel.Name = "itemPannel";
            itemPannel.BackColor = Color.FromArgb(27, 42, 71);
            itemPannel.Size = new Size(430, 40);
            itemPannel.TabIndex = index;
            this.Controls.Add(itemPannel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
