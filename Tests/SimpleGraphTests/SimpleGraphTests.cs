using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleGraphTests
{
    [TestClass]
    public class SimpleGraphTests
    {
        [TestMethod]
        public void AddVertex_1v_in_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(5);
            testGraph.AddVertex(19);

            foreach (Vertex<int> item in testGraph.vertex)
            {
                if (item != null)
                    Console.Write(item.Value + ", ");
                else
                    Console.Write("null, ");
            }

            Assert.IsTrue(testGraph.vertex[0].Value == 19);
            Assert.AreEqual(size, testGraph.max_vertex);
            Assert.AreEqual(size, testGraph.vertex.Length);
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(0));
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(1));
            Assert.AreEqual(0, testGraph.m_adjacency[0, 0]);
        }

        [TestMethod]
        public void AddVertex_5v_in_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            Assert.IsTrue(testGraph.vertex[0].Value == 19);
            Assert.IsTrue(testGraph.vertex[1].Value == 18);
            Assert.IsTrue(testGraph.vertex[2].Value == 17);
            Assert.IsTrue(testGraph.vertex[3].Value == 16);
            Assert.IsTrue(testGraph.vertex[4].Value == 15);
            Assert.AreEqual(size, testGraph.max_vertex);
            Assert.AreEqual(size, testGraph.vertex.Length);
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(0));
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(1));
            Assert.AreEqual(0, testGraph.m_adjacency[0, 0]);
            Assert.AreEqual(0, testGraph.m_adjacency[1, 0]);
            Assert.AreEqual(0, testGraph.m_adjacency[2, 0]);
            Assert.AreEqual(0, testGraph.m_adjacency[3, 0]);
            Assert.AreEqual(0, testGraph.m_adjacency[4, 0]);

        }

        [TestMethod]
        public void AddVertex_6v_in_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);
            testGraph.AddVertex(331);

            Assert.IsTrue(testGraph.vertex[0].Value == 19);
            Assert.IsTrue(testGraph.vertex[1].Value == 18);
            Assert.IsTrue(testGraph.vertex[2].Value == 17);
            Assert.IsTrue(testGraph.vertex[3].Value == 16);
            Assert.IsTrue(testGraph.vertex[4].Value == 15);
            Assert.AreEqual(size, testGraph.max_vertex);
            Assert.AreEqual(size, testGraph.vertex.Length);
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(0));
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(1));
        }

        [TestMethod]
        public void AddEdge_1e_in_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            Assert.IsTrue(testGraph.vertex[0].Value == 19);
            Assert.IsTrue(testGraph.vertex[1].Value == 18);
            Assert.IsTrue(testGraph.vertex[2].Value == 17);
            Assert.IsTrue(testGraph.vertex[3].Value == 16);
            Assert.IsTrue(testGraph.vertex[4].Value == 15);
            Assert.AreEqual(size, testGraph.max_vertex);
            Assert.AreEqual(size, testGraph.vertex.Length);
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(0));
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(1));
            Assert.AreEqual(0, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, testGraph.m_adjacency[2, 0]);


            testGraph.AddEdge(0, 2); // добавление ребра между вершинами
            testGraph.AddEdge(2, 0); // повторное добавление ребра
            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            Assert.AreEqual(1, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 0]);
        }

        [TestMethod]
        public void AddEdge_5e_in_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            Assert.IsTrue(testGraph.vertex[0].Value == 19);
            Assert.IsTrue(testGraph.vertex[1].Value == 18);
            Assert.IsTrue(testGraph.vertex[2].Value == 17);
            Assert.IsTrue(testGraph.vertex[3].Value == 16);
            Assert.IsTrue(testGraph.vertex[4].Value == 15);
            Assert.AreEqual(size, testGraph.max_vertex);
            Assert.AreEqual(size, testGraph.vertex.Length);
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(0));
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(1));
            Assert.AreEqual(0, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, testGraph.m_adjacency[2, 0]);


            testGraph.AddEdge(0, 1); // добавление ребра между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(2, 1);
            testGraph.AddEdge(2, 3);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            Assert.AreEqual(1, testGraph.m_adjacency[0, 1]);
            Assert.AreEqual(1, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(1, testGraph.m_adjacency[0, 3]);
            Assert.AreEqual(1, testGraph.m_adjacency[1, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[1, 2]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 1]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 3]);
            Assert.AreEqual(1, testGraph.m_adjacency[3, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[3, 2]);
        }

        [TestMethod]
        public void AddEdge_in_5v_Graph_If_v1_Is_not_Exists()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);

            testGraph.AddEdge(0, 4);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }
            Assert.IsTrue(testGraph.vertex[0].Value == 19); // вершина не изменились
            Assert.IsTrue(testGraph.vertex[1].Value == 18);
            Assert.IsTrue(testGraph.vertex[2].Value == 17);
            Assert.IsTrue(testGraph.vertex[3].Value == 16);
            Assert.IsNull(testGraph.vertex[4]); // вершина не существует
            Assert.AreEqual(0, testGraph.m_adjacency[0, 4]); // ребро не добавлено к v0
            Assert.AreEqual(0, testGraph.m_adjacency[4, 0]); // ребро не добавлено к v4
        }

        [TestMethod]
        public void AddEdge_1e_to_1v_and_Itself_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            Assert.IsTrue(testGraph.vertex[0].Value == 19);
            Assert.IsTrue(testGraph.vertex[1].Value == 18);
            Assert.IsTrue(testGraph.vertex[2].Value == 17);
            Assert.IsTrue(testGraph.vertex[3].Value == 16);
            Assert.IsTrue(testGraph.vertex[4].Value == 15);
            Assert.AreEqual(size, testGraph.max_vertex);
            Assert.AreEqual(size, testGraph.vertex.Length);
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(0));
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(1));
            Assert.AreEqual(0, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, testGraph.m_adjacency[2, 0]);


            testGraph.AddEdge(0, 0); // добавление ребра между вершинами

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            Assert.AreEqual(1, testGraph.m_adjacency[0, 0]);
        }

        [TestMethod]
        public void RemoveEdge_between_1v_and_Itself_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            Assert.IsTrue(testGraph.vertex[0].Value == 19);
            Assert.IsTrue(testGraph.vertex[1].Value == 18);
            Assert.IsTrue(testGraph.vertex[2].Value == 17);
            Assert.IsTrue(testGraph.vertex[3].Value == 16);
            Assert.IsTrue(testGraph.vertex[4].Value == 15);
            Assert.AreEqual(size, testGraph.max_vertex);
            Assert.AreEqual(size, testGraph.vertex.Length);
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(0));
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(1));
            Assert.AreEqual(0, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, testGraph.m_adjacency[2, 0]);


            testGraph.AddEdge(0, 0); // добавление ребра между вершинами
            testGraph.AddEdge(0, 1);
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(2, 1);
            testGraph.AddEdge(2, 3);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Assert.AreEqual(1, testGraph.m_adjacency[0, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[0, 1]);
            Assert.AreEqual(1, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(1, testGraph.m_adjacency[0, 3]);
            Assert.AreEqual(1, testGraph.m_adjacency[1, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[1, 2]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 1]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 3]);
            Assert.AreEqual(1, testGraph.m_adjacency[3, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[3, 2]);

            testGraph.RemoveEdge(0, 0); // удаление ребра между вершиной и самой себя

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            Assert.AreEqual(0, testGraph.m_adjacency[0, 0]);
        }

        [TestMethod]
        public void RemoveEdge_5e_in_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            Assert.IsTrue(testGraph.vertex[0].Value == 19);
            Assert.IsTrue(testGraph.vertex[1].Value == 18);
            Assert.IsTrue(testGraph.vertex[2].Value == 17);
            Assert.IsTrue(testGraph.vertex[3].Value == 16);
            Assert.IsTrue(testGraph.vertex[4].Value == 15);

            Assert.AreEqual(size, testGraph.max_vertex);
            Assert.AreEqual(size, testGraph.vertex.Length);
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(0));
            Assert.AreEqual(size, testGraph.m_adjacency.GetLength(1));
            Assert.AreEqual(0, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, testGraph.m_adjacency[2, 0]);


            testGraph.AddEdge(0, 1); // добавление ребра между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(2, 1);
            testGraph.AddEdge(2, 3);

            Assert.IsTrue(testGraph.IsEdge(0, 1)); // проверка добавления ребёр
            Assert.IsTrue(testGraph.IsEdge(0, 2));
            Assert.IsTrue(testGraph.IsEdge(0, 3));
            Assert.IsTrue(testGraph.IsEdge(2, 1));
            Assert.IsTrue(testGraph.IsEdge(2, 3));

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            Assert.AreEqual(1, testGraph.m_adjacency[0, 1]);
            Assert.AreEqual(1, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(1, testGraph.m_adjacency[0, 3]);
            Assert.AreEqual(1, testGraph.m_adjacency[1, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[1, 2]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 1]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 3]);
            Assert.AreEqual(1, testGraph.m_adjacency[3, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[3, 2]);

            testGraph.RemoveEdge(0, 1); // удаление ребер между вершинами
            testGraph.RemoveEdge(0, 2);
            testGraph.RemoveEdge(0, 3);
            testGraph.RemoveEdge(2, 1);
            testGraph.RemoveEdge(2, 3);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        [TestMethod]
        public void RemoveVertex_1v_in_5v_Graph()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);

            testGraph.AddVertex(19);
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            testGraph.AddEdge(0, 0); // добавление ребёр между вершинами
            testGraph.AddEdge(0, 1);
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(2, 1);
            testGraph.AddEdge(2, 3);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            testGraph.RemoveVertex(0); // удаление вершины

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            Assert.AreEqual(0, testGraph.m_adjacency[0, 0]); // проверка удаления ребра вершины на саму себя
            Assert.AreEqual(0, testGraph.m_adjacency[0, 1]); // проверка удаления всех рёбер
            Assert.AreEqual(0, testGraph.m_adjacency[1, 0]);
            Assert.AreEqual(0, testGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, testGraph.m_adjacency[2, 0]);
            Assert.AreEqual(0, testGraph.m_adjacency[0, 3]);
            Assert.AreEqual(0, testGraph.m_adjacency[3, 0]);
            Assert.AreEqual(1, testGraph.m_adjacency[1, 2]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 1]);
            Assert.AreEqual(1, testGraph.m_adjacency[2, 3]);
            Assert.AreEqual(1, testGraph.m_adjacency[3, 2]);

            Assert.IsNull(testGraph.vertex[0]); // вершина удалена
        }

        [TestMethod]
        public void DepthFirstSearch_5_Vertex()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(19); // добавляем вершины
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(0, 4);
            testGraph.AddEdge(1, 2);
            testGraph.AddEdge(1, 3);
            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(3, 4);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            List<Vertex<int>> vList = testGraph.DepthFirstSearch(1, 4); // попытка построения пути из 1 (ключ 18) в 4 (ключ 15).

            vList.ForEach((item) => Console.WriteLine(item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 3);
            Assert.AreEqual(18, vList[0].Value);
            Assert.AreEqual(19, vList[1].Value);
            Assert.AreEqual(15, vList[2].Value);
        }

        [TestMethod]
        public void DepthFirstSearch_5_Vertex_where_1v_has_not_Adj()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(19); // добавляем вершины
            testGraph.AddVertex(18);
            testGraph.AddVertex(17);
            testGraph.AddVertex(16);
            testGraph.AddVertex(15);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 4);
            testGraph.AddEdge(1, 3);
            testGraph.AddEdge(3, 4);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            List<Vertex<int>> vList = testGraph.DepthFirstSearch(0, 2); // попытка построения пути из 0 (ключ 19) в 2 (ключ 17).
            List<Vertex<int>> vList2 = testGraph.DepthFirstSearch(1, 2); // 1 (ключ 18) в 2 (ключ 17).
            List<Vertex<int>> vList3 = testGraph.DepthFirstSearch(3, 2); // 3 (ключ 16) в 2 (ключ 17).
            List<Vertex<int>> vList4 = testGraph.DepthFirstSearch(4, 2); // 4 (ключ 15) в 2 (ключ 17).

            vList.ForEach((item) => Console.WriteLine(item.Value));
            vList2.ForEach((item) => Console.WriteLine(item.Value));
            vList3.ForEach((item) => Console.WriteLine(item.Value));
            vList4.ForEach((item) => Console.WriteLine(item.Value));

            Assert.IsNotNull(vList);
            Assert.IsNotNull(vList2);
            Assert.IsNotNull(vList3);
            Assert.IsNotNull(vList4);
            Assert.IsTrue(vList.Count == 0);
            Assert.IsTrue(vList2.Count == 0);
            Assert.IsTrue(vList3.Count == 0);
            Assert.IsTrue(vList4.Count == 0);
        }

        [TestMethod]
        public void DepthFirstSearch_7_Vertex_where_Suboptimal_Path()
        {
            int size = 7;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(10); // добавляем вершины
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(70); // вершина короткого пути
            testGraph.AddVertex(60);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 5);
            testGraph.AddEdge(1, 2);
            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(3, 4);
            testGraph.AddEdge(4, 6);
            testGraph.AddEdge(5, 6);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            List<Vertex<int>> vList = testGraph.DepthFirstSearch(0, 6); // попытка построения пути из 0 (ключ 10) в 6 (ключ 60).

            vList.ForEach((item) => Console.WriteLine(item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 6);
        }

        [TestMethod]
        public void DepthFirstSearch_7_Vertex_where_Only_Path()
        {
            int size = 7;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(10); // добавляем вершины
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(70);
            testGraph.AddVertex(60);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 5);
            testGraph.AddEdge(1, 2);
            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(3, 4);
            testGraph.AddEdge(5, 6);

            for (int i = 0; i < testGraph.m_adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < testGraph.m_adjacency.GetLength(1); j++)
                {
                    Console.Write(testGraph.m_adjacency[i, j] + " ");
                }
                Console.WriteLine();
            }

            List<Vertex<int>> vList = testGraph.DepthFirstSearch(0, 6); // попытка построения пути из 0 (ключ 10) в 6 (ключ 60).

            vList.ForEach((item) => Console.WriteLine(item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 3);
        }

        [TestMethod]
        public void BreadthFirstSearch_12_Vertex_where_3_Path()
        {
            int size = 12;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(60);
            testGraph.AddVertex(70);
            testGraph.AddVertex(80);
            testGraph.AddVertex(90);
            testGraph.AddVertex(100);
            testGraph.AddVertex(110);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);

            testGraph.AddEdge(1, 4);
            testGraph.AddEdge(2, 5);
            testGraph.AddEdge(3, 6);

            testGraph.AddEdge(4, 7);
            testGraph.AddEdge(5, 8);
            testGraph.AddEdge(6, 9);

            testGraph.AddEdge(7, 10);
            testGraph.AddEdge(8, 10);
            testGraph.AddEdge(8, 11);
            testGraph.AddEdge(9, 11);

            List<Vertex<int>> vList = testGraph.BreadthFirstSearch(0, 8); // попытка построения пути из 0 (0) в 8 (80).
            Console.Write("Путь : ");
            vList.ForEach((item) => Console.Write(" {0}", item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 4);
        }

        [TestMethod]
        public void BreadthFirstSearch_9_Vertex_where_3_Path()
        {
            int size = 9;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(60);
            testGraph.AddVertex(70);
            testGraph.AddVertex(80);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);

            testGraph.AddEdge(1, 4);
            testGraph.AddEdge(2, 5);
            testGraph.AddEdge(3, 6);

            testGraph.AddEdge(4, 7);
            testGraph.AddEdge(5, 7);
            testGraph.AddEdge(5, 8);

            testGraph.AddEdge(6, 8);

            List<Vertex<int>> vList = testGraph.BreadthFirstSearch(0, 5); // попытка построения пути из 0 (0) в 5 (50).
            vList.ForEach((item) => Console.Write(" {0}", item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 3);
        }

        [TestMethod]
        public void BreadthFirstSearch_10_Vertex_Where_Path_is_not_Exists()
        {
            int size = 10;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(60);
            testGraph.AddVertex(70);
            testGraph.AddVertex(80);

            testGraph.AddVertex(90); // ребро без связей

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);

            testGraph.AddEdge(1, 4);
            testGraph.AddEdge(2, 5);
            testGraph.AddEdge(3, 6);

            testGraph.AddEdge(4, 7);
            testGraph.AddEdge(5, 7);
            testGraph.AddEdge(5, 8);

            testGraph.AddEdge(6, 8);

            List<Vertex<int>> vList = testGraph.BreadthFirstSearch(0, 9); // попытка построения пути из 0 (0) в  9 (90).
            vList.ForEach((item) => Console.Write(" {0}", item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 0);
        }

        [TestMethod]
        public void BreadthFirstSearch_5_Vertex_Where_path_has_not_Adj()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(0, 4);

            testGraph.AddEdge(1, 2);
            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(3, 4);

            List<Vertex<int>> vList = testGraph.BreadthFirstSearch(0, 2); // попытка построения пути из 0 (0) в 2 (20).
            vList.ForEach((item) => Console.Write(" {0}", item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 3);
        }

        [TestMethod]
        public void BreadthFirstSearch_5_Vertex_Where_path_has_2v()
        {
            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(0, 4);

            testGraph.AddEdge(1, 2);
            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(3, 4);

            List<Vertex<int>> vList = testGraph.BreadthFirstSearch(0, 4); // попытка построения пути из 0 (0) в 4 (40).
            vList.ForEach((item) => Console.Write(" {0}", item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 2);
        }

        [TestMethod]
        public void BreadthFirstSearch_13_Vertex_20_Edges()
        {
            int size = 13;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(60);
            testGraph.AddVertex(70);
            testGraph.AddVertex(80);
            testGraph.AddVertex(90);
            testGraph.AddVertex(100);
            testGraph.AddVertex(110);
            testGraph.AddVertex(120);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(1, 4);
            testGraph.AddEdge(1, 5);

            testGraph.AddEdge(1, 6);
            testGraph.AddEdge(2, 6);
            testGraph.AddEdge(3, 6);
            testGraph.AddEdge(3, 7);
            testGraph.AddEdge(3, 8);

            testGraph.AddEdge(4, 10);
            testGraph.AddEdge(5, 10);
            testGraph.AddEdge(6, 10);
            testGraph.AddEdge(6, 9);
            testGraph.AddEdge(6, 12);

            testGraph.AddEdge(7, 12);
            testGraph.AddEdge(8, 12);
            testGraph.AddEdge(9, 11);
            testGraph.AddEdge(10, 11);
            testGraph.AddEdge(11, 12);

            //List<Vertex<int>> vList = testGraph.BreadthFirstSearch(3, 10); // попытка построения пути из 30 в 100.
            //List<Vertex<int>> vList = testGraph.BreadthFirstSearch(9, 12); // попытка построения пути из 90 в 120.
            //List<Vertex<int>> vList = testGraph.BreadthFirstSearch(9, 11); // попытка построения пути из 90 в 110.
            //List<Vertex<int>> vList = testGraph.BreadthFirstSearch(12, 5); // попытка построения пути из 120 в 50.
            List<Vertex<int>> vList = testGraph.BreadthFirstSearch(5, 12); // попытка построения пути из 50 в 120.

            Console.WriteLine("Путь : ");
            vList.ForEach((item) => Console.Write(" {0}", item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 4);
        }

        [TestMethod]
        public void BreadthFirstSearch_12_Vertex_14_Edges()
        {
            int size = 12;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(60);
            testGraph.AddVertex(70);
            testGraph.AddVertex(80);
            testGraph.AddVertex(90);
            testGraph.AddVertex(100);
            testGraph.AddVertex(110);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(1, 4);
            testGraph.AddEdge(2, 4);

            testGraph.AddEdge(2, 6);
            testGraph.AddEdge(3, 6);
            testGraph.AddEdge(4, 5);
            testGraph.AddEdge(5, 6);

            testGraph.AddEdge(7, 8);
            testGraph.AddEdge(7, 10);
            testGraph.AddEdge(8, 9);
            testGraph.AddEdge(10, 11);
            testGraph.AddEdge(9, 11);

            List<Vertex<int>> vList = testGraph.BreadthFirstSearch(7, 9); // попытка построения пути из 70 в 90.
            List<Vertex<int>> vList2 = testGraph.BreadthFirstSearch(4, 3); // попытка построения пути из 40 в 30.
            vList.ForEach((item) => Console.Write(" {0}", item.Value));
            Console.WriteLine();
            vList2.ForEach((item) => Console.Write(" {0}", item.Value));

            Assert.IsNotNull(vList);
            Assert.IsTrue(vList.Count == 3);
            Assert.IsTrue(vList2.Count == 4);
        }

        [TestMethod]
        public void BreadthFirstSearch_6_Vertex_where_1v_is_Closured()
        {
            int size = 6;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(1, 3);
            testGraph.AddEdge(1, 4);

            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(3, 3);
            testGraph.AddEdge(3, 4);
            testGraph.AddEdge(4, 5);

            List<Vertex<int>> vList = testGraph.BreadthFirstSearch(3, 5); // попытка построения пути из 30 в 50.
            //Console.WriteLine("Путь 3 -> 5: ");
            //vList.ForEach((item) => Console.Write(" {0}", item.Value));

            List<Vertex<int>> vList2 = testGraph.BreadthFirstSearch(2, 5); // попытка построения пути из 20 в 50.
            //Console.WriteLine("Путь 2 -> 5: ");
            //vList2.ForEach((item) => Console.Write(" {0}", item.Value));

            Assert.IsNotNull(vList);
            Assert.IsNotNull(vList2);
            Assert.IsTrue(vList.Count == 3);
            Assert.IsTrue(vList2.Count == 4);
        }

        [TestMethod]
        public void WeakVertices_in_9v_where_2v_Is_Weak()
        {

            int size = 9;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(60);
            testGraph.AddVertex(70);
            testGraph.AddVertex(80);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(0, 4);
            testGraph.AddEdge(1, 5);
            testGraph.AddEdge(2, 5);
            testGraph.AddEdge(2, 6);

            testGraph.AddEdge(3, 4);
            testGraph.AddEdge(4, 5);
            testGraph.AddEdge(5, 6);
            testGraph.AddEdge(3, 7);
            testGraph.AddEdge(4, 7);
            testGraph.AddEdge(6, 8);

            List<Vertex<int>> WeakList = testGraph.WeakVertices();

            int expectedCount = 2;
            int actualCount = WeakList.Count;

            WeakList.ForEach((item) => Console.Write("{0} ", item.Value));

            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsTrue(WeakList[0].Value == 10);
            Assert.IsTrue(WeakList[1].Value == 80);
        }

        [TestMethod]
        public void WeakVertices_in_3v_where_All_Is_Weak()
        {

            int size = 3;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);

            List<Vertex<int>> WeakList = testGraph.WeakVertices();

            int expectedCount = 3;
            int actualCount = WeakList.Count;

            WeakList.ForEach((item) => Console.Write("{0} ", item.Value));

            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsTrue(WeakList[0].Value == 0);
            Assert.IsTrue(WeakList[1].Value == 10);
            Assert.IsTrue(WeakList[2].Value == 20);
        }

        [TestMethod]
        public void WeakVertices_in_3v_where_Graph_Is_Triangle()
        {

            int size = 3;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(1, 2);

            List<Vertex<int>> WeakList = testGraph.WeakVertices();

            int expectedCount = 0;
            int actualCount = WeakList.Count;
            if (WeakList.Count != 0)
                WeakList.ForEach((item) => Console.Write("{0} ", item.Value));
            else
                Console.WriteLine("[]");

            Assert.IsNotNull(WeakList);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void WeakVertices_in_5v_where_2v_Is_Weak()
        {

            int size = 5;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(30);
            testGraph.AddVertex(50);
            testGraph.AddVertex(70);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(0, 4);
            testGraph.AddEdge(3, 4);

            List<Vertex<int>> WeakList = testGraph.WeakVertices();

            int expectedCount = 2;
            int actualCount = WeakList.Count;
            if (WeakList.Count != 0)
                WeakList.ForEach((item) => Console.Write("{0} ", item.Value));
            else
                Console.WriteLine("[]");

            Assert.IsNotNull(WeakList);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsTrue(WeakList[0].Value == 10);
            Assert.IsTrue(WeakList[1].Value == 30);
        }

        [TestMethod]
        public void WeakVertices_in_7v_where_All_Is_Adj()
        {

            int size = 7;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);
            testGraph.AddVertex(50);
            testGraph.AddVertex(60);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 2);
            testGraph.AddEdge(0, 3);
            testGraph.AddEdge(0, 4);
            testGraph.AddEdge(0, 5);
            testGraph.AddEdge(0, 6);

            testGraph.AddEdge(1, 2);
            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(3, 4);
            testGraph.AddEdge(4, 5);
            testGraph.AddEdge(5, 6);
            testGraph.AddEdge(1, 6);

            List<Vertex<int>> WeakList = testGraph.WeakVertices();

            int expectedCount = 0;
            int actualCount = WeakList.Count;

            if (WeakList.Count != 0)
                WeakList.ForEach((item) => Console.Write("{0} ", item.Value));
            else
                Console.WriteLine("[]");

            Assert.IsNotNull(WeakList);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void WeakVertices_15v_where_7v_Is_Weak()
        {

            int size = 15;
            SimpleGraph<int> testGraph = new SimpleGraph<int>(size);
            testGraph.AddVertex(0); // добавляем вершины
            testGraph.AddVertex(10);
            testGraph.AddVertex(20);
            testGraph.AddVertex(30);
            testGraph.AddVertex(40);

            testGraph.AddVertex(50);
            testGraph.AddVertex(60);
            testGraph.AddVertex(70);
            testGraph.AddVertex(80);
            testGraph.AddVertex(90);

            testGraph.AddVertex(100);
            testGraph.AddVertex(110);
            testGraph.AddVertex(120);
            testGraph.AddVertex(130);
            testGraph.AddVertex(140);

            testGraph.AddEdge(0, 1); // добавление рёбер между вершинами
            testGraph.AddEdge(0, 4);
            testGraph.AddEdge(1, 4);
            testGraph.AddEdge(2, 3);
            testGraph.AddEdge(2, 5);
            testGraph.AddEdge(4, 6);

            testGraph.AddEdge(6, 7);
            testGraph.AddEdge(5, 7);
            testGraph.AddEdge(5, 8);
            testGraph.AddEdge(5, 9);
            testGraph.AddEdge(7, 8);
            testGraph.AddEdge(8, 9);

            testGraph.AddEdge(9, 10);
            testGraph.AddEdge(7, 11);
            testGraph.AddEdge(8, 11);
            testGraph.AddEdge(9, 11);
            testGraph.AddEdge(10, 12);
            testGraph.AddEdge(11, 14);

            testGraph.AddEdge(13, 14);


            List<Vertex<int>> WeakList = testGraph.WeakVertices();

            int expectedCount = 7;
            int actualCount = WeakList.Count;

            if (WeakList.Count != 0)
                WeakList.ForEach((item) => Console.Write("{0} ", item.Value));
            else
                Console.WriteLine("[]");

            Assert.IsNotNull(WeakList);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsTrue(WeakList[0].Value == 20);
            Assert.IsTrue(WeakList[1].Value == 30);
            Assert.IsTrue(WeakList[2].Value == 60);
            Assert.IsTrue(WeakList[3].Value == 100);
            Assert.IsTrue(WeakList[4].Value == 120);
            Assert.IsTrue(WeakList[5].Value == 130);
            Assert.IsTrue(WeakList[6].Value == 140);

        }
    }
}
