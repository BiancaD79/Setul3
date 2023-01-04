using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Setul3_FP
{
    class Program
    {
        public static int[] ReadArray(int n)
        {
            int[] v = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"v[{i}]= ");
                v[i] = int.Parse(Console.ReadLine());
            }
            return v;
        }
        public static int[] ReadArray(string s)
        {
            
            char[] sep = {' ',',',';'};
            string[] line = s.Split(sep);
            int[] v = new int[line.Length] ;
            for (int i = 0; i < line.Length; i++)
            {
                v[i] = int.Parse(line[i]);
            }
            
            return v;
        }
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
        public static void PrintArray(int[] array, int until)
        {
            for (int i = 0; i < until; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        public static void Sort(int[] v)
        {
            int n = v.Length;
            for (int i = 1; i < n; i++)
            {
                int j = i;
                while (j > 0 && v[j] < v[j - 1])
                {
                    int aux;
                    aux = v[j - 1];
                    v[j - 1] = v[j];
                    v[j] = aux;
                    j--;
                }
            }
        }
        public static void SwapInArray(int[] array,int a, int b)
        {
            int aux = array[a];
            array[a] = array[b];
            array[b] = aux;
        }
        static void Main(string[] args)
        {
            int prob, ok = 1;
            do
            {
                Console.Clear();
                Console.Write("Alegeti o problema: ");
                prob = int.Parse(Console.ReadLine());
                if (prob < 1 || prob > 31) Console.Write("Nu ati introdus un numar corect!");
                else
                {
                    switch (prob)
                    {
                        case 1: P1(); break;
                        case 2: P2(); break;
                        case 3: P3(); break;
                        case 4: P4(); break;
                        case 5: P5(); break;
                        case 6: P6(); break;
                        case 7: P7(); break;
                        case 8: P8(); break;
                        case 9: P9(); break;
                        case 10: P10(); break;
                        case 11: P11(); break;
                        case 12: P12(); break;
                        case 13: P13(); break;
                        case 14: P14(); break;
                        case 15: P15(); break;
                        case 16: P16(); break;
                        case 17: P17(); break;
                        case 18: P18(); break;
                        case 19: P19(); break;
                        case 20: P20(); break;
                        case 21: P21(); break;
                        case 22: P22(); break;
                        case 23: P23(); break;
                        case 24: P24(); break;
                        case 25: P25(); break;
                        case 26: P26(); break;
                        case 27: P27(); break;
                        case 28: P28(); break;
                        case 29: P29(); break;
                        case 30: P30(); break;
                        case 31: P31(); break;
                    }

                }
                Console.Write("\nDoriti sa alegeti alta problema?: 0 - Nu, 1 - Da ");
                ok = int.Parse(Console.ReadLine());
            } while (ok != 0);
        }

        /// <summary>
        /// (Element majoritate). Intr-un vector cu n elemente, un element m este element majoritate daca mai mult de n/2 din valorile vectorului sunt egale cu m (prin urmare, daca un vector are element majoritate acesta este unui singur).  
        /// Sa se determine elementul majoritate al unui vector (daca nu exista atunci se va afisa nu exista). (incercati sa gasiti o solutie liniara). 
        /// </summary>
        private static void P31()
        {
            Console.WriteLine("Introduceti vectorul,elementele separate prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            List<int> elemente = new List<int>();
            int[] apar = new int[v.Length];
            int j = 0;
            int maj=0; bool existamaj = false;
            for (int i = 0; i < v.Length; i++)
            {
                if (elemente.Contains(v[i])) apar[elemente.IndexOf(v[i])]++;
                if(!elemente.Contains(v[i])){ elemente.Add(v[i]);apar[j]=1; j++; }
            }
            for (int i = 0; i < apar.Length; i++)
            {
                if (apar[i] > v.Length / 2) { maj = elemente[i]; existamaj = true; break; }
            }
            if (!existamaj)
            {
                Console.WriteLine("Nu exista element majoritate.");
            }
            else
                Console.WriteLine($"Elementul majoritate este {maj}");

        }
        /// <summary>
        /// Sortare bicriteriala. Se dau doi vectori de numere intregi E si W, unde E[i] este un numar iar W[i] este un numar care reprezinta ponderea lui E[i]. 
        /// Sortati vectorii astfel incat elementele lui E sa fie in in ordine crescatoare iar pentru doua valori egale din E, cea cu pondere mai mare va fi prima. 
        /// </summary>
        private static void P30()
        {
            Console.WriteLine("Introduceti vectorul E,elementele separate prin spatiu: ");
            int[] E = ReadArray(Console.ReadLine());
            Console.WriteLine("Introduceti vectorul W,elementele separate prin spatiu: ");
            int[] W = ReadArray(Console.ReadLine());
            if (E.Length != W.Length) {Console.WriteLine("Nu ati introdus un numar egal de elemente!"); return; }
            SortWithWeight(E,W,0,E.Length-1);
            Console.Write("E = ");
            PrintArray(E);
            Console.Write("W = ");
            PrintArray(W);

        }

        private static void SortWithWeight(int[] e, int[] w, int low, int high)
        {
            if (low < high)
            {
                int i = partitionWeight(e,w, low, high);
                SortWithWeight(e, w,low, i - 1);
                SortWithWeight(e, w,i + 1, high);
            }
        }

        private static int partitionWeight(int[] e, int[] w, int low, int high)
        {
            int pivotE = e[high];
            int pivotW = w[high];
            int index = low - 1;
            for (int j = low; j < high; j++)
            {
                if (e[j] < pivotE || (e[j] == pivotE && w[j] > pivotW))
                {
                    index++;
                    SwapInArray(e, index, j);
                    SwapInArray(w, index, j);
                }
                
            }
            SwapInArray(e, index + 1, high);
            SwapInArray(w, index + 1, high);
            return (index + 1);
        }

        static void MergeSort(int[] v, int st, int dr)
        {
            if (st<dr)
            {
                int mij = st + (dr-st) / 2;
                MergeSort(v, st, mij);
                MergeSort(v, mij + 1, dr);
                Merge(v, st, mij, dr);
            }
        }

        private static void Merge(int[] v, int st, int mij, int dr)
        {
            int p1 = mij - st + 1;
            int p2 = dr - mij;
            int[] ST = new int[p1];
            int[] DR = new int[p2];
            int i, j;
            for (i = 0; i < p1; ++i)
                ST[i] = v[st + i];
            for (j = 0; j < p2; ++j)
                DR[j] = v[mij + 1 + j];
            i = j = 0;
            int k = st;
            while(i < p1 && j < p2)
            {
                if(ST[i] <= DR[j])
                {
                    v[k] = ST[i];
                    i++;
                }
                else
                {
                    v[k] = DR[j];
                    j++;
                }
                k++;
            }
            while(i<p1)
            {
                v[k] = ST[i];
                i++;k++;
            }
            while (j < p2)
            {
                v[k] = DR[j];
                j++; k++;
            }
        }

        /// <summary>
        /// Sortati un vector folosind metoda MergeSort.
        /// </summary>
        private static void P29() 
        {
            Console.WriteLine("Introduceti vectorul,elementele separate prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            MergeSort(v, 0,v.Length-1);
            PrintArray(v);
        }
        //returns the position where the pivot goes, it also puts it in the right position
        static int partition(int[] v,int low, int high)
        {
            int pivot = v[high];
            int index = low - 1;
            for (int j = low; j < high; j++)
            {
                if(v[j] < pivot)
                {
                    index++;
                    SwapInArray(v,index,j);
                }    
            }
            SwapInArray(v,index+1,high);
            return (index + 1); 
        }
        static void QuickSort(int[] v,int low, int high)
        {
            if(low < high)
            {
                int i = partition(v,low,high);
                QuickSort(v, low, i-1);
                QuickSort(v, i+1, high);
            }
        }
        /// <summary>
        /// Sortati un vector folosind metoda QuickSort. 
        /// </summary>
        private static void P28()
        {
            //Lomuto Partition
            Console.WriteLine("Introduceti vectorul,elementele separate prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            QuickSort(v, 0, v.Length-1);
            PrintArray(v);
        }
        /// <summary>
        /// Se da un vector si un index in vectorul respectiv. 
        /// Se cere sa se determine valoarea din vector care va fi pe pozitia index dupa ce vectorul este sortat. 
        /// </summary>
        private static void P27()
        {
            Console.WriteLine("Introduceti vectorul,elementele separate prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            Console.WriteLine($"Introduceti k,un index din vector 0<=k<={v.Length-1}: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine($"Elementul pe pozitia {k} inainte de sortare este {v[k]}.");
            QuickSort(v, 0, v.Length - 1);
            Console.WriteLine($"Elementul pe pozitia {k} dupa sortare este {v[k]}.");
            PrintArray(v);
        }
        /// <summary>
        /// Se dau doua numere naturale foarte mari (cifrele unui numar foarte mare sunt stocate intr-un vector - fiecare cifra pe cate o pozitie). 
        /// Se cere sa se determine suma, diferenta si produsul a doua astfel de numere. 
        /// </summary>
        private static void P26()
        {
            Console.WriteLine("Introduceti primul numar: ");
            int[] nr1 = ReadArray(Console.ReadLine());
            Console.WriteLine("Introduceti al doilea numar: ");
            int[] nr2 = ReadArray(Console.ReadLine());
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < nr1.Length; i++)
            {
                str.Append(nr1[i]);
            }
            string A = str.ToString();
            str.Clear();
            for (int i = 0; i < nr2.Length; i++)
            {
                str.Append(nr2[i]);
            }
            string B = str.ToString();
            BigInteger a = BigInteger.Parse(A);
            BigInteger b = BigInteger.Parse(B);
            Console.WriteLine($"{a} + {b} = {a+b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{a} * {b} = {a * b}");
        }
        /// <summary>
        /// (Interclasare) Se dau doi vector sortati crescator v1 si v2. 
        /// Construiti un al treilea vector ordonat crescator format din toate elementele din  v1 si v2. 
        /// Sunt permise elemente duplicate. 
        /// </summary>
        private static void P25()
        {
            Console.WriteLine("Introduceti primul vector,elementele separate prin spatiu: ");
            int[] v1 = ReadArray(Console.ReadLine());
            Console.WriteLine("Introduceti al doilea vector,elementele separate prin spatiu:  ");
            int[] v2 = ReadArray(Console.ReadLine());
            List<int> v = new List<int>();
            int i, j;
            i = j = 0;
            while (i < v1.Length && j < v2.Length)
            {
                if (v1[i] < v2[j])
                    v.Add(v1[i++]);
                else
                    v.Add(v2[j++]);
            }
            while(i< v1.Length)
                v.Add(v1[i++]);
            while(j < v2.Length)
                v.Add(v2[j++]);
            for (int k = 0; k < v.Count; k++)
            {
                Console.Write( v[k] + " ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Aceleasi cerinte ca si la problema anterioara dar de data asta elementele sunt stocate ca vectori cu valori binare 
        /// (v[i] este 1 daca i face parte din multime si este 0 in caz contrar).
        /// </summary>
        private static void P24()
        {
            Console.Write("Introduceti lungimea multimii: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            List<int> M1 = new List<int>();
            for (int i = 0; i < v.Length; i++)
            {
                if (!(v[i] == 1 || v[i] == 0)) { Console.WriteLine("Vectorul nu contine valori potrivite!"); return; }
                if (v[i] == 1 && !M1.Contains(i)) M1.Add(i);
            }
            Console.Write("Introduceti lungimea urmatoarei multimi: ");
            n = int.Parse(Console.ReadLine());
            v = ReadArray(n);
            List<int> M2 = new List<int>();
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == 1 && !M2.Contains(i)) M2.Add(i);
            }
            //Uniune
            List<int> op = new List<int>(M1);
            for (int i = 0; i < M2.Count; i++)
            {
                if (!op.Contains(M2[i])) op.Add(M2[i]);
            }
            op.Sort();
            Console.WriteLine($"M1 = {string.Join(",", M1)} \nM2 = {string.Join(",", M2)}");
            Console.WriteLine($"Uniunea multimii M1 cu M2 este {string.Join(",", op)}");
            op.Clear();

            //Intersectare
            for (int i = 0; i < M2.Count; i++)
            {
                if (M1.Contains(M2[i])) op.Add(M2[i]);
            }
            op.Sort();
            Console.WriteLine($"Intersectia multimii M1 cu M2 este {string.Join(",", op)}");
            op.Clear();

            //M1 / M2
            List<int> M1Copy = new List<int>(M1);
            op = M1;
            for (int i = 0; i < M2.Count; i++)
            {
                op.Remove(M2[i]);
            }
            Console.WriteLine($"Diferenta M1/M2 este {string.Join(",", op)}");
            op.Clear();
            M1 = M1Copy;
            //M2 / M1

            op = M2;
            for (int i = 0; i < M1.Count; i++)
            {
                op.Remove(M1[i]);
            }
            Console.WriteLine($"Diferenta M2/M1 este {string.Join(",", op)}");
        }

        /// <summary>
        /// Aceleasi cerinte ca si la problema anterioara dar de data asta elementele din v1 respectiv v2  sunt in ordine strict crescatoare. 
        /// </summary>
        private static void P23()
        {
            P22();
        }
        /// <summary>
        /// Se dau doi vectori v1 si v2. Se cere sa determine intersectia, reuniunea, si diferentele v1-v2 si v2 -v1 
        /// (implementarea operatiilor cu multimi). 
        /// Elementele care se repeta vor fi scrise o singura data in rezultat. 
        /// </summary>
        private static void P22()
        {
            Console.Write("Introduceti lungimea multimii: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            List<int> M1 = new List<int>();
            for (int i = 0; i < v.Length; i++)
            {
                if(!M1.Contains(v[i]))M1.Add(v[i]);
            }
            Console.Write("Introduceti lungimea urmatoarei multimi: ");
            n = int.Parse(Console.ReadLine());
            v = ReadArray(n);
            List<int> M2 = new List<int>();
            for (int i = 0; i < v.Length; i++)
            {
                if (!M2.Contains(v[i])) M2.Add(v[i]);
            }
            //Uniune
            List<int> op = new List<int>(M1);
            for (int i = 0; i < M2.Count; i++)
            {
                if(!op.Contains(M2[i])) op.Add(M2[i]);
            }
            op.Sort();
            Console.WriteLine($"M1 = {string.Join(",", M1)} \nM2 = {string.Join(",", M2)}");
            Console.WriteLine($"Uniunea multimii M1 cu M2 este {string.Join(",", op)}" );
            op.Clear();

            //Intersectare
            for (int i = 0; i < M2.Count; i++)
            {
                if (M1.Contains(M2[i])) op.Add(M2[i]);
            }
            op.Sort();
            Console.WriteLine($"Intersectia multimii M1 cu M2 este {string.Join(",", op)}");
            op.Clear();

            //M1 / M2
            List<int> M1Copy = new List<int>(M1);
            op = M1;
            for (int i = 0; i < M2.Count; i++)
            {
                op.Remove(M2[i]);
            }
            Console.WriteLine($"Diferenta M1/M2 este {string.Join(",", op)}");
            op.Clear();
            M1 = M1Copy;
            //M2 / M1

            op = M2;
            for (int i = 0; i < M1.Count; i++)
            {
                op.Remove(M1[i]);
            }
            Console.WriteLine($"Diferenta M2/M1 este {string.Join(",", op)}");
        }
        /// <summary>
        /// Se dau doi vectori. Se cere sa se determine ordinea lor lexicografica 
        /// (care ar trebui sa apara primul in dictionar). 
        /// </summary>
        private static void P21()
        {
            Console.WriteLine("Introduceti primul vector ");
            string[] v1 = Console.ReadLine().Split(' ');
            Console.WriteLine("Introduceti al doilea vector ");
            string[] v2 = Console.ReadLine().Split(' ');
            string s1 = string.Join("", v1);
            string s2 = string.Join("", v2);
            if (s1 == s2) Console.WriteLine("Sunt egal lexicografic");
            else
                if(s1.CompareTo(s2) < 0) Console.WriteLine("Primul sir precede pe al doilea.");
                else
                    Console.WriteLine("Al doilea sir precede pe prima.");
        }
        /// <summary>
        /// Se dau doua siraguri de margele formate din margele albe si negre, notate s1, respectiv s2. 
        /// Determinati numarul de suprapuneri (margea cu margea) a unui sirag peste celalalt astfel incat margelele suprapuse au aceeasi culoare. 
        /// Siragurile de margele se pot roti atunci cand le suprapunem. 
        /// </summary>
        private static void P20()
        {
            //Confused
            Console.WriteLine("Introduceti primul sirag de margele, elementele despartite prin spatiu: ");
            string[] s1 = Console.ReadLine().Split(' ');
            Console.WriteLine("Introduceti al doilea sirag de margele, elementele despartite prin spatiu: ");
            string[] s2 = Console.ReadLine().Split(' ');
            int countMax = 0;
            if (s1.Length != s2.Length) { Console.WriteLine("Introduceti un numar egal de margele!");P20(); }
            for (int i = 0; i < s1.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < s1.Length; j++)
                {
                    if (s1[j] == s2[j]) count++;
                }
                if (count > countMax) countMax = count;
                RotireStanga(s1);
            }
            Console.WriteLine($"Numarul maxim de margele care se suprapun este {countMax}");
        }

        private static void RotireStanga(string[] s1)
        {
            string aux = s1[0];
            for (int i = 0; i < s1.Length-1; i++)
            {
                s1[i] = s1[i + 1];
            }
            s1[s1.Length-1] = aux;
        }

        /// <summary>
        /// Se da un vector s (vectorul in care se cauta) si un vector p (vectorul care se cauta). 
        /// Determinati de cate ori apare p in s. De ex. Daca s = [1,2,1,2,1,3,1,2,1] si p = [1,2,1] atunci p apare in s de 3 ori. 
        /// (Problema este dificila doar daca o rezolvati cu un algoritm liniar). 
        /// </summary>
        private static void P19()
        {
            Console.WriteLine("Introduceti vectorul, elementele despartite prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            Console.WriteLine("Introduceti secventa cautata, elementele despartite prin spatiu: ");
            int[] p = ReadArray(Console.ReadLine());
            string line = string.Join("", v);
            string tofind = string.Join("", p);
            int occurance = 0;
            
            for (int i = 0; i <= line.Length - tofind.Length; i++)
            {
                if (line.IndexOf(tofind, i, tofind.Length) != -1)
                    occurance++;
            }
            Console.WriteLine(tofind + $" apare de {occurance} ori.");
        }
        /// <summary>
        /// Se da un polinom de grad n ai carui coeficienti sunt stocati intr-un vector. 
        /// Cel mai putin semnificativ coeficient este pe pozitia zero in vector. 
        /// Se cere valoarea polinomului intr-un punct x. 
        /// </summary>
        private static void P18()
        {
            Console.Write("Introduceti gradul polinomului: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti coeficientii polinomului: ");
            int[] v = ReadArray(n);
            Console.Write("Introduceti valoarea punctului: ");
            int x = int.Parse(Console.ReadLine());
            int s = 0;
            StringBuilder str = new StringBuilder();
            for (int i = n-1; i >=0; i--)
            {
                str.Append($"{v[i]}*{x}^{i+1}+ ");
                s += (int)(Math.Pow(x, i + 1)) * v[i]; 
            }
            str.Remove(str.Length - 2,2);
            Console.WriteLine($"Valoarea polinomului {str} este {s}");
        }
        /// <summary>
        /// Se da un numar n in baza 10 si un numar b. 1 < b < 17. Sa se converteasca si sa se afiseze numarul n in baza b.   
        /// </summary>
        private static void P17()
        {
            Console.Write("Introduceti numarul n in baza 10: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Introduceti baza de convertire: ");
            int baza = int.Parse(Console.ReadLine());
            List<int> LI = new List<int>();
            StringBuilder final = new StringBuilder();
            if (n == 0) LI.Add(0);
            while (n != 0)
            {
                LI.Add(n % baza);
                n /= baza;
            }
            for (int i = LI.Count - 1; i >= 0; i--)
            {
                switch (LI[i])
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        final.Append(LI[i]); break;
                    case 10: final.Append('A'); break;
                    case 11: final.Append('B'); break;
                    case 12: final.Append('C'); break;
                    case 13: final.Append('D'); break;
                    case 14: final.Append('E'); break;
                    case 15: final.Append('F'); break;
                }

            }
            Console.WriteLine(final.ToString());
        }
        private static int cmmdc(int a, int b)
        {
            if (a == 0) return b;
            return cmmdc(b % a, a);
        }
        /// <summary>
        /// Se da un vector de n numere naturale. Determinati cel mai mare divizor comun al elementelor vectorului.
        /// </summary>
        private static void P16()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            int gcd= v[0];
            for (int i = 1; i < v.Length; i++)
            {
                gcd = cmmdc(v[i], gcd);
                if (gcd == 1) break;
            }
            Console.WriteLine("Cel mai mare divizor comun este "+ gcd);

        }
        /// <summary>
        /// Modificati un vector prin eliminarea elementelor care se repeta, fara a folosi un alt vector. 
        /// </summary>
        private static void P15()
        {
            Console.WriteLine("Introduceti vectorul,elementele separate prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            int n = v.Length;
            Sort(v); // prin sortare
            int i = 0;
            while(i<n-1)
            {
                if (v[i] == v[i + 1])
                {
                    for (int j = i+1; j < n - 1; j++)
                    {
                        v[j] = v[j + 1];
                    }
                    n--;
                }
                else
                    i++;
            }
            PrintArray(v,n);
            /*for (int i = 0; i < v.Length-1; i++)
            {
                for (int j = i+1; j < v.Length; j++)
                {
                    if (v[i] == v[j] && j < v.Length - 1)
                    {
                        for (int k = j; k < v.Length-1; k++)
                        {
                            v[k] = v[k + 1];
                        }
                        n--;
                    }
                    if (j == v.Length - 1) n--;
                    
                }
            }
            PrintArray(v, n);*/

        }
        /// <summary>
        /// Interschimbati elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit.
        /// </summary>
        private static void P14()
        {
            Console.WriteLine("Introduceti vectorul,elementele separate prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            int n = v.Length;
            int j = n-1 ;
            for (int i = 0; i < j; i++)
            {
                if(v[i] == 0)
                {
                    while (v[j] == 0 && j > i) j--;
                    v[i] = v[j];
                    v[j] = 0;
                }
            }
            PrintArray(v);
        }
        /// <summary>
        /// Insertion Sort
        /// </summary>
        private static void P13()
        {
            Console.WriteLine("Introduceti vectorul,elementele separate prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            int n = v.Length;
            for (int i = 1; i < n; i++)
            {
                int j = i;
                while(j > 0 && v[j] < v[j-1])
                {
                    int aux;
                    aux = v[j - 1];
                    v[j - 1] = v[j];
                    v[j] = aux;
                    j--;
                }
            }
            PrintArray(v);
        }
        /// <summary>
        /// Selection Sort
        /// </summary>
        private static void P12()
        {
            Console.WriteLine("Introduceti vectorul,elementele separate prin spatiu: ");
            int[] v = ReadArray(Console.ReadLine());
            int n = v.Length;
            for (int i = 0; i < n-1; i++)
            {
                int min = i;
                for (int j = i+1; j < n; j++)
                    if (v[j] < v[min]) min = j;
                int aux = v[i];
                v[i] = v[min];
                v[min] = aux;
            }
            PrintArray(v);
        }
        /// <summary>
        /// Se da un numar natural n. Se cere sa se afiseze toate numerele prime mai mici sau egale cu n
        /// </summary>
        private static void P11()
        {
            // Sieve of Eratosthenes
            Console.Write("Introduceti numarul n: ");
            int n = int.Parse(Console.ReadLine());
            bool[] v = new bool[n+1];
            for (int i = 2; i*i < n; i++)
            {
                if(v[i] == false)
                {
                    for (int j = i*i; j < n; j+=i)
                    {
                        v[j] = true;
                    }
                }
            }

            for (int i = 2; i < n; i++)
            {
                if(v[i] == false)
                Console.Write(i + " ");
            }
            Console.WriteLine();

        }
        /// <summary>
        /// Se da un vector cu n elemente sortat in ordine crescatoare. Se cere sa se determine pozitia unui element dat k. Daca elementul nu se gaseste in vector rezultatul va fi -1. 
        /// </summary>
        private static void P10()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            Console.Write("Introduceti elementul cautat: ");
            int el = int.Parse(Console.ReadLine());
            int mij = n / 2;
            int st = 0, dr = n-1, k = -1;
            while(st < dr)
            {
                if (el > v[mij])
                {
                    st = mij+1;
                    mij = (st + dr) / 2;
                }
                else
                    if (el < v[mij])
                {
                    dr = mij+1;
                    mij = (st + dr) / 2;
                }
                else
                { k = mij; break;}
            }
            Console.WriteLine($"Elementul {el} se gaseste pe pozitia {k}");
        }
        /// <summary>
        ///  Se da un vector cu n elemente. Rotiti elementele vectorului cu k pozitii spre stanga. 
        /// </summary>
        private static void P9()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            Console.Write("Introduceti numarul k: ");
            int k = int.Parse(Console.ReadLine());
            int j = 1;
            while(j!=k && j < k)
            {
                RotireStanga(v);
                j++;
            }
            PrintArray(v);
        }

        private static void RotireStanga(int[] v)
        {
            int aux = v[0];
            for (int i = 0; i < v.Length-1; i++)
            {
                v[i] = v[i + 1];
            }
            v[v.Length - 1] = aux;
        }

        /// <summary>
        /// Se da un vector cu n elemente. Rotiti elementele vectorului cu o pozitie spre stanga.
        /// </summary>
        private static void P8()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            RotireStanga(v);
            PrintArray(v);
        }
        /// <summary>
        ///  Se da un vector nu n elemente. Se cere sa se inverseze ordinea elementelor din vector.
        /// </summary>
        private static void P7()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            for (int i = 0; i < n/2; i++)
            {
                int aux;
                aux = v[i];
                v[i] = v[n - 1 - i];
                v[n - 1 - i] = aux;
            }
            PrintArray(v);
        }
        /// <summary>
        /// Se da un vector cu n elemente si o pozitie din vector k. Se cere sa se stearga din vector elementul de pe pozitia k. Prin stergerea unui element, toate elementele din dreapta lui se muta cu o pozitie spre stanga. 
        /// </summary>
        private static void P6()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            Console.Write("Introduceti numarul k: ");
            int k = int.Parse(Console.ReadLine());
            if (k < 0 || k >= n)
            { Console.WriteLine("k trebuie se fie pozitiv si mai mic decat " + n); return; }
            for (int i = k; i < n-1; i++)
            {
                v[i] = v[i + 1];
            }
            n--;
            PrintArray(v,n);
        }

        /// <summary>
        /// Se da un vector cu n elemente, o valoare e si o pozitie din vector k. Se cere sa se insereze valoarea e in vector pe pozitia k. Primul element al vectorului se considera pe pozitia zero. 
        /// </summary>
        private static void P5()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Introduceti numarul k: ");
            int k = int.Parse(Console.ReadLine());
            if (k < 0 || k >= n)
            { Console.WriteLine("k trebuie se fie pozitiv si mai mic decat " + n); return; }
            Console.Write("Introduceti numarul e: ");
            int e = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            v[k] = e;
            PrintArray(v);

        }
        /// <summary>
        /// Deteminati printr-o singura parcurgere, cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea. 
        /// </summary>
        private static void P4()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            int aparmin = 1, max , min, aparmax = 1;
            if (n != 0)
                v[0] = int.Parse(Console.ReadLine());
            else
            { Console.WriteLine("n nu poate fi 0"); return; } //throw new ArgumentException("nu nu poate fi 0");
            max = min = v[0];
            for (int i = 1; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
                if (v[i] == max) aparmax++;
                if (v[i] == min) aparmin++;
                if (v[i] > max) { aparmax = 1; max = v[i]; }
                else
                    if (v[i] < min) { aparmin = 1; min = v[i]; }
            }
            Console.WriteLine($"Elementul maxim este {max}si apare de {aparmax}, iar cel minim {min} si apare de {aparmin}.");

        }
        /// <summary>
        /// Sa se determine pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului.
        /// </summary>
        private static void P3()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            int min = -1, max=-1;
            /*for (int i = 0; i < n-1; i++)
            {
                if (v[i] > v[max]) max = i;
                else
                    if (v[i] < v[min]) min = i;
            }*/
            int i;
            if (n % 2 != 0)
            {
                min = 0; max = 0;
                i = 1;
            }
            else
            {
                if(v[0]> v[1])
                {
                    max = 0; min = 1;
                }
                else
                { max = 1;min = 0; }
                i = 2;
            }
            for (; i < n - 1 ; i+=2)
            {
                    if (v[i] > v[i + 1])
                    { 
                        if (v[i] > v[max]) max = i;
                        if (v[i+1] < v[min]) min = i+1; 
                    }
                    else
                    {
                        if (v[i+1] > v[max]) max = i+1;
                        if (v[i] < v[min]) min = i;
                    }

            }
            Console.WriteLine($"Elementul maxim are pozitia {max}, iar cel minim {min}.");
        }
        /// <summary>
        /// Se da un vector cu n elemente si o valoare k. Se cere sa se determine prima pozitie din vector pe care apare k. Daca k nu apare in vector rezultatul va fi -1. 
        /// </summary>
        private static void P2()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Introduceti numarul k: ");
            int k = int.Parse(Console.ReadLine());
            int[] v = ReadArray(n);
            int poz = -1;
            for (int i = 0; i < n; i++)
            {
                if (v[n] == k) { poz = i; break; }
            
            }
            //if (poz != -1) Console.WriteLine($"{k} e pe pozitita {poz}");
            //else
            //    Console.WriteLine($"{k} nu e inclus in vector");
            Console.WriteLine(poz);

        }
        /// <summary>
        /// Calculati suma elementelor unui vector de n numere citite de la tastatura. Rezultatul se va afisa pe ecran.
        /// </summary>
        private static void P1()
        {
            Console.Write("Introduceti lungimea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
                s += v[i];
            }
            Console.WriteLine($"Suma elementelor este {s}");
        }
    }
}
