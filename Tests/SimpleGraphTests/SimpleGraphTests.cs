using System;
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
    }
}
