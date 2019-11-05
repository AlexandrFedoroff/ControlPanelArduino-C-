using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ControlPanelArduino
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }


        private void DataForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "conrolPanelDBDataSet6.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.conrolPanelDBDataSet6.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "conrolPanelDBDataSet.Table". При необходимости она может быть перемещена или удалена.
            //this.tableTableAdapter.Fill(this.conrolPanelDBDataSet.Table);
           
            //Программно отображаем поля записи. Двигает по записям bindingNavigator1 
            label12.DataBindings.Add(new Binding("Text", tableBindingSource, "HU", true));
            label13.DataBindings.Add(new Binding("Text", tableBindingSource, "TE", true));
            label14.DataBindings.Add(new Binding("Text", tableBindingSource, "IL", true));
            
            chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chart2.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            //Программно передвигаемя ро записям
            //tableBindingSource.MoveLast(); //На последнюю запись
            //tableBindingSource.MoveNext(); //На одну запись вперед

            /*
            // * //Настройки без волшебника
            chart2.Series[0].XValueMember = conrolPanelDBDataSet6.Tables[0].Columns[1].ToString(); //"Влажность"
            chart2.Series[0].YValueMembers = conrolPanelDBDataSet6.Tables[0].Columns[2].ToString();
            conrolPanelDBDataSet6.Tables[0].Columns[2] = 

            chart2.Series["Температура"].XValueMember = (conrolPanelDBDataSet6.Tables[0].Columns[1]).ToString(); //Температура
            chart2.Series["Температура"].YValueMembers = (conrolPanelDBDataSet6.Tables[0].Columns[3]).ToString();

            chart2.Series["Освещение"].XValueMember = (conrolPanelDBDataSet6.Tables[0].Columns[1]).ToString(); //Освещение
            chart2.Series["Освещение"].YValueMembers = (conrolPanelDBDataSet6.Tables[0].Columns[4]).ToString();
            
            chart2.DataBind(); 
            */
            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            chart2.Update(); //Обновление Chart

            //chart2.Series[0].XValueMember = (conrolPanelDBDataSet6.Tables[0].Columns[1]).ToString(); //"Влажность"
            //chart2.Series[0].YValueMembers = (conrolPanelDBDataSet6.Tables[0].Columns[2]).ToString();

            //chart2.Series["Температура"].XValueMember = (conrolPanelDBDataSet6.Tables[0].Columns[1]).ToString(); //Температура
            //chart2.Series["Температура"].YValueMembers = (conrolPanelDBDataSet6.Tables[0].Columns[3]).ToString();

            //chart2.Series["Освещение"].XValueMember = (conrolPanelDBDataSet6.Tables[0].Columns[1]).ToString(); //Освещение
            //chart2.Series["Освещение"].YValueMembers = (conrolPanelDBDataSet6.Tables[0].Columns[4]).ToString();

            chart2.DataBind();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            tableBindingSource.EndEdit(); //Сохранение полей ввода bindingNavigator
            tableTableAdapter.Update(conrolPanelDBDataSet6.Table); //Сохранение полей ввода bindingNavigator
            //this.someTableTableAdapter.Update(this.someDataSet.SomeTable);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void tableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
/* private void btnfirst_Click(object sender, EventArgs e)
       {
           bindingSource1.MoveFirst();
       }

       private void btnnext_Click(object sender, EventArgs e)
       {
           bindingSource1.MoveNext();
       }

       private void btnprevious_Click(object sender, EventArgs e)
       {
           bindingSource1.MovePrevious();
       }

       private void btnlast_Click(object sender, EventArgs e)
       {
           bindingSource1.MoveLast();
       }

       private void btnsavechanges_Click(object sender, EventArgs e)
       {
           bindingSource1.EndEdit();
       }

       private void btncancelchanges_Click(object sender, EventArgs e)
       {
           bindingSource1.CancelEdit();
       }

       private void btnremove_Click(object sender, EventArgs e)
       {
           bindingSource1.RemoveCurrent();
       }*/
