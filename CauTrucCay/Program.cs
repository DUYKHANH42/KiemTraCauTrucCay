﻿using System;
using System.Text;

/*
  MSSV: 2421160014
  Ho va ten: Đặng Nguyễn Duy Khanh
  Lớp: C24A.TH1
 */

namespace CauTrucCay
{

    //cau 1
    interface ITree
    {
        void ThemNut(ref TNode root, int x);
        void TaoCay();
        void LNR(TNode root);
        int DemSoNut(TNode root);
        int DemSoNutLa(TNode root);
        int TinhTong(TNode root);
        int TimMin(TNode root);
    }
    class TNode
    {
        public int data;
        public TNode left;
        public TNode right;

        public TNode(int x)
        {
            //viết code thực hiện khỏi tạo nú
            this.data = x;
            left = null;
            right = null;
        }
    }
    class BST : ITree
    {
        public TNode root;
        public BST()
        {
            this.root = null;
        }

        //viet code cho cac phuong thuc sau 
        public void ThemNut(ref TNode root, int x)
        {
            if (root == null)
            {
                TNode p = new TNode(x);
                root = p;
            }

            else if (root.data > x)
            {
                ThemNut(ref root.left, x);
            }
            else if (root.data < x)
            {
                ThemNut(ref root.right, x);
            }
        }
        public void TaoCay()
        {
            Console.WriteLine("Nhập Số Lượng Phần Tử Của Cây: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Nhap phan tu thu {0}: ", i);
                int x = int.Parse(Console.ReadLine());
                ThemNut(ref this.root, x);
            }
        }
        public void XoaCay()
        {
            if (root == null)
            {
                Console.WriteLine("Cây rỗng");
            }
            else
            {
                Console.WriteLine("Xóa cây thành công");

            }
        }
        public void LNR(TNode root)  //duyet cay theo thu tu giua
        {
            if (root != null)
            {
                LNR(root.left);
                Console.Write(root.data + " ");
                LNR(root.right);
            }
        }
        public int DemSoNut(TNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + DemSoNut(root.left) + DemSoNut(root.right);

        }

        public int DemSoNutLa(TNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1 + DemSoNutLa(root.left) + DemSoNutLa(root.right);
            }
            return DemSoNutLa(root.left) + DemSoNutLa(root.right);
        }

        public int TimMin(TNode root)
        {
            if (root.left == null)
            {
                return root.data;
            }
            return TimMin(root.left);
        }

        public int TinhTong(TNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return root.data + TinhTong(root.left) + TinhTong(root.right);
        }
        public void XoaCay(ref TNode root)
        {
            if (root != null)
            {
                XoaCay(ref root.left);
                XoaCay(ref root.right);
                root = null;
                Console.WriteLine("Xóa cây thành công");
            }
            else
            {
                Console.WriteLine("Cây rỗng");
            }
        }



        //cau 2
        class Program
        {
            static void Main(string[] args)
            {
                MeNu.Menu();
                Console.ReadKey();
            }
        }
        class MeNu
        {
            public static void clear()
            {
                Console.Clear();
            }
            public static void Menu()
            {
                Console.OutputEncoding = Encoding.UTF8;
                BST tree = new BST();
                int chon;
                do
                {
                    Console.WriteLine("Chương trình quản lý cây nhị phân tìm kiếm");
                    Console.WriteLine("1. Tạo Cây");
                    Console.WriteLine("2. Thêm Nút");
                    Console.WriteLine("3. Duyệt cây theo LNR");
                    Console.WriteLine("4. Đếm số nút của cây");
                    Console.WriteLine("5. Đếm số nút lá của cây");
                    Console.WriteLine("6. Tìm phần tử nhỏ nhất của cây");
                    Console.WriteLine("7. Tính tổng các phần tử trong cây");
                    Console.WriteLine("8. Xóa cây");
                    Console.WriteLine("9.Thoát");
                    chon = int.Parse(Console.ReadLine());
                    switch (chon)
                    {
                        case 1:
                            clear();
                            tree.TaoCay();
                            break;
                        case 2:
                            clear();
                            Console.WriteLine("Nhập Phần Tử Cần Thêm: ");
                            int x = int.Parse(Console.ReadLine());
                            tree.ThemNut(ref tree.root, x);
                            break;
                        case 3:
                            clear();
                            Console.WriteLine("Duyệt Cây Theo LNR: ");
                            tree.LNR(tree.root);
                            Console.WriteLine();
                            break;
                        case 4:
                            clear();
                            Console.WriteLine("Số Nút Của Cây: {0}", tree.DemSoNut(tree.root));
                            break;
                        case 5:
                            clear();
                            Console.WriteLine("Số Nút Lá Của Cây: {0}", tree.DemSoNutLa(tree.root));
                            break;
                        case 6:
                            clear();
                            Console.WriteLine("Phần Tử Nhỏ Nhất Của Cây: {0}", tree.TimMin(tree.root));
                            break;
                        case 7:
                            clear();
                            Console.WriteLine("Tổng Các Phần Tử Trong Cây: {0}", tree.TinhTong(tree.root));
                            break;
                        case 8:
                            clear();
                            tree.XoaCay(ref tree.root);
                            break;
                        case 9:
                            clear();
                            Console.WriteLine("Hẹn Gặp Lại!");
                            break;
                        default:
                            clear();
                            Console.WriteLine("Chức năng không tồn tại");
                            break;
                    }
                }
                while (chon != 9);
            }
        }
    }
}
