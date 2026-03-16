using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Duoi_Hinh_Bat_Chu
{
    public partial class Form1 : Form
    {
        public string TenNguoiChoi;
        public Form1()
        {
            InitializeComponent();
            this.Load -= Form1_Load;
            this.Load += Form1_Load;

           
        }
        int diem = 0;
        int diemCauHienTai = 10;
        int soGoiYConLai = 3;
        Random rd = new Random();
        string[] listHinhAnh;
        int index;
        int[] listindexDaDung;
        int indexdadung;
        string[] listDapAn = { "BAOCAO",
                                "BAHOA",
                                "CUNGCAU",
                                "CADAO",
                                "CANBANG",
                                "MATMA",
                                "GIAYBAC",
                                "XAKEP",
                                "CHIDIEM",
                                "DONGCAMCONGKHO"};

        TextBox[] txtDapAn;
        Button[] listGoiYDapAn;
        private void Form1_Load(object sender, EventArgs e)
        {
            // tạo button thoát
            #region Hieu_Ung_Button_Thoat
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = Color.DarkRed;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Maroon;

            btnExit.BackColor = Color.Red;
            btnExit.ForeColor = Color.White;

            btnExit.Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);

            btnExit.Cursor = Cursors.Hand;
            btnExit.TabStop = false;
            #endregion
            #region Hieu_Ung_Button_Hint_Goi_y
            btnHint.FlatStyle = FlatStyle.Flat;
            btnHint.FlatAppearance.BorderSize = 0;
            btnHint.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            btnHint.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;

            btnHint.BackColor = Color.DimGray;
            btnHint.ForeColor = Color.White;

            btnHint.Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnHint.Cursor = Cursors.Hand;
            btnHint.TabStop = false;
            #endregion
            #region Hieu_Ung_NuT_Diem
            btn_Diem.FlatStyle = FlatStyle.Flat;
            btn_Diem.FlatAppearance.BorderSize = 0;
            btn_Diem.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            btn_Diem.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;

            btn_Diem.BackColor = Color.DimGray;
            btn_Diem.ForeColor = Color.White;

            btn_Diem.Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_Diem.Cursor = Cursors.Hand;
            btn_Diem.TabStop = false;
            #endregion
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            btnHint.Text = $"Gợi ý: {soGoiYConLai}";
            btn_Diem.Text = "Điểm: ";
            listHinhAnh = new string[10];

            //load hình ảnh ngẫu nhiên 
            for (int i = 1; i <= listHinhAnh.Length; i++)
            {
                listHinhAnh[i - 1] = "hinh_anh_duoi_hinh_bat_chu\\" + i + ".PNG";
            }
            listindexDaDung = new int[listHinhAnh.Length];

            index = rd.Next(0, listHinhAnh.Length);
            indexdadung = 0;
            listindexDaDung[indexdadung] = index;

            ptrHinhAnh.BackgroundImage = Image.FromFile(listHinhAnh[index]);
            ptrHinhAnh.BackgroundImageLayout = ImageLayout.Stretch;
         

            HienThiTuDongDapAn();
            HienThiCacNutGoiYDapAn();
            PhatSinhGoiYDapAn();
        }
        //sinh ra các text ở trong nút button gợi ý đáp án
        private void PhatSinhGoiYDapAn()
        {
            char[] DanhSachKyTuGoiYDapAn = new char[listGoiYDapAn.Length];
            //đưa ký tự đáp án vào
            for (int i = 0; i < DanhSachKyTuGoiYDapAn.Length / 2; i++)
            {
                char kytu = listDapAn[index][i];
                if (char.IsLower(kytu))
                {
                    DanhSachKyTuGoiYDapAn[i] = (char)(kytu - 32);//A:65 còn a:97
                }
                else
                {
                    DanhSachKyTuGoiYDapAn[i] = kytu;
                }
            }
            Random x = new Random();
            // phát sinh ngẫu nhiên các kỹ tự còn lại
            for (int i = DanhSachKyTuGoiYDapAn.Length / 2; i < DanhSachKyTuGoiYDapAn.Length; i++)
            {

                DanhSachKyTuGoiYDapAn[i] = (char)x.Next(65, 91);// tu 65->91 là các kỹ tự in hoa trong bảng mã ASCII

            }
            int[] mangindexdadung = new int[listGoiYDapAn.Length];
            int soluong = 0;
            // trộn lẫn và đọc lên button

            for (int i = 0; i < listGoiYDapAn.Length; i++)
            {
                bool check;
                do
                {
                    Random rd = new Random();
                    int idx = rd.Next(0, listGoiYDapAn.Length);
                    //kiểm tra xem trùng hay  ko
                    check = true;
                    for (int j = 0; j < soluong; j++)
                    {
                        if (idx == mangindexdadung[j])
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check == true)
                    {
                        // Hiển thị ký tự lên button
                        listGoiYDapAn[i].Text = DanhSachKyTuGoiYDapAn[idx].ToString();
                        // cập nhật các idx vào danh sách index đã dùng của danh dách gợi ý đáp án
                        mangindexdadung[soluong++] = idx;
                    }
                } while (check == false);
            }
        }
        // sinh ra  các text box tự động  dựa theo đáp án câu hỏi
        private void HienThiTuDongDapAn()
        {
            int soluongtextbox = listDapAn[index].Length;
            txtDapAn = new TextBox[soluongtextbox];


            txtDapAn[0] = new TextBox();
            txtDapAn[0].Location = new Point(ptrHinhAnh.Location.X, ptrHinhAnh.Location.Y + ptrHinhAnh.Size.Height + 10);
            txtDapAn[0].Size = new Size(30, 30);
            txtDapAn[0].Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtDapAn[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), (((int)(((byte)(192))))));

            txtDapAn[0].Click += Form1_Click;

            this.Controls.Add(txtDapAn[0]);
            for (int i = 1; i < soluongtextbox; ++i)
            {
                txtDapAn[i] = new TextBox();
                txtDapAn[i].Location = new Point(txtDapAn[i - 1].Location.X + txtDapAn[i - 1].Size.Width + 10, txtDapAn[0].Location.Y);
                txtDapAn[i].Size = new Size(30, 30);
                txtDapAn[i].Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
                txtDapAn[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), (((int)(((byte)(192))))));


                txtDapAn[i].Click += Form1_Click;
                this.Controls.Add(txtDapAn[i]);
            }
        }
        // sinh ra các button tự động và các ký tự gợi ý đáp án
        private void HienThiCacNutGoiYDapAn()
        {
            /* phát sinh tự động các gợi ý đáp án */
            listGoiYDapAn = new Button[txtDapAn.Length * 2];
            //button 0
            listGoiYDapAn[0] = new Button();
            listGoiYDapAn[0].Location = new Point(ptrHinhAnh.Location.X + ptrHinhAnh.Size.Width + 30, ptrHinhAnh.Location.Y);
            listGoiYDapAn[0].Size = new Size(50, 30);

            listGoiYDapAn[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), (((int)(((byte)(255))))));
            listGoiYDapAn[0].ForeColor = System.Drawing.SystemColors.Highlight;
            listGoiYDapAn[0].Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);

            listGoiYDapAn[0].Text = "0";
            listGoiYDapAn[0].Click += Form1_Click;
            listGoiYDapAn[0].MouseHover += Form1_MouseHover;
            listGoiYDapAn[0].MouseLeave += Form1_MouseLeave;
            //button 1
            listGoiYDapAn[1] = new Button();
            listGoiYDapAn[1].Location = new Point(listGoiYDapAn[0].Location.X + listGoiYDapAn[0].Size.Width + 30, listGoiYDapAn[0].Location.Y);
            listGoiYDapAn[1].Size = new Size(50, 30);
            //  làm đẹp button
            listGoiYDapAn[1].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), (((int)(((byte)(255))))));
            listGoiYDapAn[1].ForeColor = System.Drawing.SystemColors.Highlight;
            listGoiYDapAn[1].Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            //
            listGoiYDapAn[1].Click += Form1_Click;
            listGoiYDapAn[1].MouseHover += Form1_MouseHover;
            listGoiYDapAn[1].MouseLeave += Form1_MouseLeave;
            this.Controls.Add(listGoiYDapAn[0]);
            this.Controls.Add(listGoiYDapAn[1]);

            for (int i = 2; i < listGoiYDapAn.Length; i++)
            {

                listGoiYDapAn[i] = new Button();
                listGoiYDapAn[i].Location = new Point(listGoiYDapAn[i - 2].Location.X, listGoiYDapAn[i - 2].Location.Y + 40);
                listGoiYDapAn[i].Size = new Size(50, 30);

                listGoiYDapAn[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), (((int)(((byte)(255))))));
                listGoiYDapAn[i].ForeColor = System.Drawing.SystemColors.Highlight;
                listGoiYDapAn[i].Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);

                listGoiYDapAn[i].Click += Form1_Click;
                listGoiYDapAn[i].MouseHover += Form1_MouseHover;
                listGoiYDapAn[i].MouseLeave += Form1_MouseLeave;
                this.Controls.Add(listGoiYDapAn[i]);
            }

        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            ((Button)(sender)).Font = new System.Drawing.Font("Time New Roman", 8.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
           ((Button)(sender)).Font = new System.Drawing.Font("Time New Roman", 15.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);

        }

        // sự kiện click cho tất cả các nút nhán button và text box 
        private void Form1_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                //-điền text từ button  vào ô  text box  rỗng theo chiều từ trái qua phải o đầu tiên rỗng
                for (int i = 0; i < txtDapAn.Length; ++i)
                {
                    if (txtDapAn[i].Text == "")
                    {
                        txtDapAn[i].Text = ((Button)sender).Text;
                        ((Button)sender).Visible = false;// ẩn button đi

                        break;
                    }
                }
                // kiểm tra đã lấp đầy chưa  để kiểm tra đúng sai
                bool check = false;
                foreach (TextBox txt in txtDapAn)
                {
                    if (txt.Text == "")
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    KiemTraDungSai();
                }
            }
            else if (sender is TextBox)
            {
                //lấy text đó vào trong danh sách button bị ẩn kiêm tra xem có không thì hiện lên lại
                foreach (Button btn in listGoiYDapAn)
                {
                    if (btn.Visible == false && btn.Text == ((TextBox)sender).Text)
                    {
                        btn.Visible = true;// hiện lên lại
                        break;
                    }
                }
                //reset lại textbox
                ((TextBox)sender).ResetText();
            }
        }
        // hàm kiểm tra đúng sai 
        private void KiemTraDungSai()
        {
            bool check = false;
            foreach (TextBox txt in txtDapAn)
            {
                if (txt.Text == "")
                {
                    check = true;
                    break;
                }
            }
            if (check == false)
            {
                // tất cả các ô đã được điền đầy đủ => kiểm tra đúng sai
                string s = "";
                for (int i = 0; i < txtDapAn.Length; i++)
                {
                    s += txtDapAn[i].Text;
                }
                // so sánh s với đáp án để biết đúng sai không phân biệt đúng sai
                if (s.ToUpper() == listDapAn[index].ToUpper())
                {
                    diem += diemCauHienTai;
                    btn_Diem.Text = "Điểm :"+diem;
                    MessageBox.Show("đúng rồi! bạn được +"+diemCauHienTai+"điểm");
                    ChuyenQuaCauMoi();
                }
                else
                {
                    MessageBox.Show("sai rồi");
                    ChuyenQuaCauMoi();
                }
            }
        }
        //check đúng sai khi trả lời và chuyển qua câu tiếp - kết thúc game
        private void ChuyenQuaCauMoi()
        {
            bool check;
            do
            {
                if (indexdadung == listindexDaDung.Length - 1)
                {
                    MessageBox.Show("đã random hết hình. Bạn chiến thắng");
                    this.Close();//đóng form
                } 

                index = rd.Next(0, listHinhAnh.Length);
                check = true;
                for (int i = 0; i <= indexdadung; i++)
                {
                    if (listindexDaDung[i] == index)// phát hiện trùng index
                    {
                        check = false;
                        break;// break luôn khi phát hiện

                    }
                }
                if (check == true)// nếu không trùng hiện hình ảnh
                {
                    ptrHinhAnh.BackgroundImage = Image.FromFile(listHinhAnh[index]);
                    ptrHinhAnh.BackgroundImageLayout = ImageLayout.Stretch;
                  
                    listindexDaDung[++indexdadung] = index;// lưu vào mảng index đã dùng
                    diemCauHienTai = 10;
                    /* đoạn code phát sinh tự đọng các đáp án*/
                    int soluongtextbox = listDapAn[index].Length;
                    if (txtDapAn != null)
                    {
                        for (int i = 0; i < txtDapAn.Length; i++)
                            this.Controls.Remove(txtDapAn[i]);
                    }
                    txtDapAn = new TextBox[soluongtextbox];

                    HienThiTuDongDapAn();

                    // reset danh sách các nút gợi ý đáp án
                    foreach (Button btn in listGoiYDapAn)
                    {
                        this.Controls.Remove(btn);
                    }
                    HienThiCacNutGoiYDapAn();
                    PhatSinhGoiYDapAn();
                }
            } while (check == false);
            
        }
        // Hàm điền ký tự gọi ý ngẫu nhiên
        private bool DienMotKyTuDungNgauNhien()
        {
            int[] viTriTrong = new int[txtDapAn.Length];
            int soLuong = 0;

            // tìm các ô trống
            for (int i = 0; i < txtDapAn.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(txtDapAn[i].Text))
                {
                    viTriTrong[soLuong] = i;
                    soLuong++;
                }
            }

            if (soLuong == 0)
                return false;

            int pos = viTriTrong[rd.Next(0, soLuong)];

            char kyTuDung = char.ToUpper(listDapAn[index][pos]);
            string s = kyTuDung.ToString();
            // ẩn một ký tự ở listGoiYDapAn
            foreach (Button btn in listGoiYDapAn)
            {
                if (btn.Visible && btn.Text == s)
                {
                    btn.Visible = false;
                    break;
                }
            }

            txtDapAn[pos].Text = s;
            return true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region Thao_tac_Lien_Quan_Nut_Goi_Y
        private void btnHint_Click(object sender, EventArgs e)
        {

            if (soGoiYConLai <= 0) return;

            int soChuGoiY = 2; // mỗi lần hiện 2 chữ
            int soChuDaGoiY = 0;

            for (int i = 0; i < soChuGoiY; i++)
            {
                bool ok = DienMotKyTuDungNgauNhien();
                if (!ok) break;      // hết ô trống thì dừng
                soChuDaGoiY++;
            }

            // Chỉ trừ lượt khi thực sự gợi ý được ít nhất 1 chữ
            if (soChuDaGoiY > 0)
            {
                soGoiYConLai--;
                diemCauHienTai -= 3;
                if (diemCauHienTai < 0)
                {
                    diemCauHienTai = 0;
                }

                if (soGoiYConLai > 0)
                {
                    btnHint.Text = $"Gợi ý: {soGoiYConLai}";
                }
                else
                {
                    MessageBox.Show("Bạn đã dùng hết gợi ý!");
                    btnHint.Visible = false; // hoặc btnHint.Enabled = false;
                }

                // (Tuỳ chọn) Nếu sau khi gợi ý mà đã đầy ô => tự check đúng sai luôn
                KiemTraDungSai();
            }
        }
        #endregion

       
    }
}
