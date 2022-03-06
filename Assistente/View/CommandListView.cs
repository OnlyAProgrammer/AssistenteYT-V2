using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistente.View
{
    internal sealed partial class CommandListView : Form
    {
        internal CommandListView()
        {
            InitializeComponent();
            PopulateCommandList();
        }

        private void PopulateCommandList()
        {
            var commands = Grammatics.Builder.GetVoiceCommands();
            var h = 0;

            foreach (var c1 in commands.CommandKeyAndOptions)
            {
                var group = new ListViewGroup(c1.Key);
                var items = new List<ListViewItem>();

                foreach (var subs in c1.Value)
                {
                    var newItem = new ListViewItem(group)
                    {
                        Text = subs.Key,
                    };

                    foreach (var subItem in subs.Value)
                        newItem.SubItems.Add(new ListViewItem.ListViewSubItem(newItem, subItem));

                    if (newItem.Text.Length > h)
                        h = newItem.Text.Length;

                    items.Add(newItem);
                }

                commandList.Groups.Add(group);
                commandList.Items.AddRange(items.ToArray());
            }

            var column = new ColumnHeader()
            {
                Text = "Comandos",
                Width = h * (int)commandList.Font.Size
            };

            commandList.Width = column.Width * 2;
            commandList.Columns.Add(column);
            commandList.ItemActivate += CommandListItemActivate;
        }

        private void CommandListItemActivate(object sender, EventArgs e)
        {
            var item = commandList.SelectedItems[0];
            panelCommands.Controls.Clear();

            foreach(var subitens in item.SubItems)
            {
                var subitem = (ListViewItem.ListViewSubItem)subitens;

                if (subitem.Text == item.Text)
                {
                    labelCommandType.Text = subitem.Text;
                    continue;
                }

                var cmd = new Label()
                {
                    Text = subitem.Text,
                    Font = new Font("Verdana", 12, FontStyle.Regular),
                    ForeColor = Color.Black,
                    Dock = DockStyle.Top,
                    AutoSize = true,
                };
                panelCommands.Controls.Add(cmd);
                Update();
            }

        }
    }
}
