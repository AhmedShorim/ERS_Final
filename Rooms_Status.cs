using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERS
{
    public partial class Rooms_Status : Form
    {
        Rooms_Status_Model Model;

        public Rooms_Status()
        {
            InitializeComponent();
            Model = new Rooms_Status_Model();
            LoadRoomsInfo();
        }

        public void LoadRoomsInfo()
        {
            int box_y_pos = 40;

            int RoomCount = Model.GetNumberOfRooms();

            for (int i = 0; i < RoomCount; i++)
            {
                //GroupBox for each room

                GroupBox box = new GroupBox();
                box.Size = new Size(612, 51);
                box.Location = new Point(33, box_y_pos);
                box.Text = "Room " + Model.GetRoomName(i);
                this.Controls.Add(box);

                //Description Labels for each room

                Label Desc_lbl = new Label();
                Desc_lbl.Location = new Point(12, 25);
                Desc_lbl.Text = "Description:";
                Desc_lbl.Size = new Size(63, 13);
                Desc_lbl.ForeColor = Color.Black;
                box.Controls.Add(Desc_lbl);

                Label Desc_txt = new Label();
                Desc_txt.Location = new Point(78, 25);
                Desc_txt.Text = Model.GetRoomDesc(Model.GetRoomName(i));
                Desc_txt.ForeColor = Color.Black;
                box.Controls.Add(Desc_txt);

                //Start time labels for each room

                Label start_lbl = new Label();
                start_lbl.Location = new Point(250, 25);
                start_lbl.Text = "Start Time:";
                start_lbl.Size = new Size(63, 13);
                start_lbl.ForeColor = Color.Black;
                box.Controls.Add(start_lbl);

                Label start_txt = new Label();
                start_txt.Location = new Point(310, 25);
                start_txt.Text = Model.GetStartTime(i);
                start_txt.ForeColor = Color.Black;
                box.Controls.Add(start_txt);

                //Reservation Length for each room

                Label ResLength_lbl = new Label();
                ResLength_lbl.Location = new Point(450, 25);
                ResLength_lbl.Text = "Length:";
                ResLength_lbl.Size = new Size(46, 13);
                ResLength_lbl.ForeColor = Color.Black;
                box.Controls.Add(ResLength_lbl);

                Label ResLength_txt = new Label();
                ResLength_txt.Location = new Point(495, 25);
                ResLength_txt.Text = Model.Calc_ReservationLength(i);
                ResLength_txt.ForeColor = Color.Black;
                box.Controls.Add(ResLength_txt);

                //Incrementing Y-Coordinate for groupboxes

                box_y_pos += 70;
            }

            //Empty rooms

            List<String> EmptyRooms = new List<string>();
            EmptyRooms = Model.GetEmptyRooms();

            GroupBox empty = new GroupBox();
            empty.Size = new Size(612, 35*EmptyRooms.Count);
            empty.Location = new Point(33, box_y_pos);
            empty.Text = "Empty Rooms";
            this.Controls.Add(empty);

            int y_pos = 25;

            for (int i = 0; i < EmptyRooms.Count; i++)
            {
                Label EmptyRooms_lbl = new Label();
                EmptyRooms_lbl.Location = new Point(12, y_pos);
                EmptyRooms_lbl.Text = EmptyRooms[i];
                EmptyRooms_lbl.Size = new Size(500, 13);
                EmptyRooms_lbl.ForeColor = Color.Black;
                empty.Controls.Add(EmptyRooms_lbl);

                y_pos += 30;
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            List<Control> temp = new List<Control>();

            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    temp.Add(c);
                }
            }

            foreach (Control c in temp)
            {
                this.Controls.Remove(c);
            }

            LoadRoomsInfo();
        }
    }
}