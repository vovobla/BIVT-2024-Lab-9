using Lab_7;
using Lab_9;
using System.IO;

namespace Lab_9_White_Test
{
    [TestClass]
    public sealed class WhiteLeague
    {
        private Random _rand = new Random();
        Lab_9.WhiteSerializer[] _serializers = new Lab_9.WhiteSerializer[]
        {
            new Lab_9.WhiteTXTSerializer(),
            new Lab_9.WhiteJSONSerializer()
        };

        [TestMethod]
        public void Test_00_OOP()
        {
            var props = new (string, string[], Type)[]
            {
                new ("FolderPath", null, typeof(string)),
                new ("FilePath", null, typeof(string)),
                new ("Extension", new string[] {"abstract" }, typeof(string))
            };
            var methods = new (string, string[], Type, Type[])[]
            {
                new ("SelectFile", null, typeof(void), new Type[] {typeof(string) }),
                new ("SelectFolder", null, typeof(void), new Type[] {typeof(string) }),
                new ("SerializeWhite1Participant", null, typeof(void), new Type[] {typeof(White_1.Participant), typeof(string) }),
                new ("SerializeWhite2Participant", null, typeof(void), new Type[] { typeof(White_2.Participant), typeof(string) }),
                new ("SerializeWhite3Student", null, typeof(void), new Type[] { typeof(White_3.Student), typeof(string) }),
                new ("SerializeWhite4Human", null, typeof(void), new Type[] { typeof(White_4.Human), typeof(string) }),
                new ("SerializeWhite5Team", null, typeof(void), new Type[] { typeof(White_5.Team), typeof(string) }),
                new ("DeserializeWhite1Participant", null, typeof(White_1.Participant), new Type[] {typeof(string) }),
                new ("DeserializeWhite2Participant", null, typeof(White_2.Participant), new Type[] {typeof(string) }),
                new ("DeserializeWhite3Student", null, typeof(White_3.Student), new Type[] {typeof(string) }),
                new ("DeserializeWhite4Human", null, typeof(White_4.Human), new Type[] {typeof(string) }),
                new ("DeserializeWhite5Team", null, typeof(White_5.Team), new Type[] {typeof(string) }),
            };
            General.CheckOOP(_serializers[0], props, methods);
            General.CheckOOP(_serializers[1], props, methods);
        }
        [TestMethod]
        public void Test_01_Hierarchy()
        {
            foreach (var item in _serializers)
            {
                Assert.IsTrue(item is IFileManager);
                Assert.IsTrue(item is FileSerializer);
                Assert.IsTrue(item is WhiteSerializer);
            }
            Assert.IsTrue(_serializers[0] is WhiteTXTSerializer);
            Assert.IsFalse(_serializers[0] is WhiteJSONSerializer);
            Assert.IsFalse(_serializers[1] is WhiteTXTSerializer);
            Assert.IsTrue(_serializers[1] is WhiteJSONSerializer);
        }
        [TestMethod]
        public void Test_02_CreateFolder()
        {
            for (int i = 0; i < _serializers.Length; i++)
            {
                Assert.IsTrue(IFileManagerTest.Check_CreateFolder(_serializers[i], $"White_{i + 1}"));
            }
            CheckFolder();
        }
        [TestMethod]
        public void Test_03_CreateFile()
        {
            for (int i = 0; i < _serializers.Length; i++)
            {
                var extension = i switch
                {
                    0 => "txt",
                    1 => "json"
                };
                Assert.IsTrue(IFileManagerTest.Check_CreateFile(_serializers[i], $"White_{i + 1}", $"White_task", extension));
            }
            CheckFile();
        }
        [TestMethod]
        public void Test_04_White1_TXT()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White1_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[0].SerializeWhite1Participant(original[i], $"White_1_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_1.Participant[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[0].DeserializeWhite1Participant($"White_1_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_05_White1_JSON()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White1_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[1].SerializeWhite1Participant(original[i], $"White_1_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_1.Participant[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[1].DeserializeWhite1Participant($"White_1_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_06_White2_TXT()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White2_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[0].SerializeWhite2Participant(original[i], $"White_2_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_2.Participant[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[0].DeserializeWhite2Participant($"White_2_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_07_White2_JSON()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White1_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[1].SerializeWhite1Participant(original[i], $"White_2_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_1.Participant[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[1].DeserializeWhite1Participant($"White_2_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_08_White3_TXT()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White3_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[0].SerializeWhite3Student(original[i], $"White_3_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_3.Student[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[0].DeserializeWhite3Student($"White_3_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_09_White3_JSON()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White3_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[1].SerializeWhite3Student(original[i], $"White_3_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_3.Student[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[1].DeserializeWhite3Student($"White_3_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_10_White4_TXT()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White4_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[0].SerializeWhite4Human(original[i], $"White_4_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_4.Human[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[0].DeserializeWhite4Human($"White_4_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_11_White4_JSON()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White4_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[1].SerializeWhite4Human(original[i], $"White_4_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_4.Human[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[1].DeserializeWhite4Human($"White_4_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_12_White5_TXT()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White5_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[0].SerializeWhite5Team(original[i], $"White_5_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_5.Team[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[0].DeserializeWhite5Team($"White_5_{i + 1}");
            }
            Check(original, restored);
        }
        [TestMethod]
        public void Test_13_White5_JSON()
        {
            Init();
            Test_03_CreateFile();
            var original = Create_White5_Array();
            for (int i = 0; i < original.Length; i++)
            {
                _serializers[1].SerializeWhite5Team(original[i], $"White_5_{i + 1}");
            }
            Init();
            Test_03_CreateFile();
            var restored = new White_5.Team[original.Length];
            for (int i = 0; i < original.Length; i++)
            {
                restored[i] = _serializers[1].DeserializeWhite5Team($"White_5_{i + 1}");
            }
            Check(original, restored);
        }
        private void Init()
        {
            _serializers = new Lab_9.WhiteSerializer[]
            {
                new Lab_9.WhiteTXTSerializer(),
                new Lab_9.WhiteJSONSerializer()
            };
        }
        private void CheckFolder()
        {
            for (int i = 0; i < _serializers.Length; i++)
            {
                var pathes = IFileManagerTest.Check_Properties(_serializers[i]);
                Assert.AreEqual(pathes.folder, Path.Combine(IFileManagerTest.GeneralPath, $"White_{i + 1}"));
                Assert.AreEqual(pathes.file, null);
            }
        }

        private void CheckFile()
        {
            for (int i = 0; i < _serializers.Length; i++)
            {
                var extension = i switch
                {
                    0 => "txt",
                    1 => "json"
                };
                var pathes = IFileManagerTest.Check_Properties(_serializers[i]);
                Assert.AreEqual(pathes.folder, Path.Combine(IFileManagerTest.GeneralPath, $"White_{i + 1}"));
                Assert.AreEqual(pathes.file, Path.Combine(IFileManagerTest.GeneralPath, $"White_{i + 1}", $"White_task.{extension}"));
            }
        }
        private White_1.Participant[] Create_White1_Array()
        {
            var participants = new White_1.Participant[10]
            {
                new White_1.Participant("Vasya", "CSKA"),
                new White_1.Participant("Petya", "CSKA"),
                new White_1.Participant("Kolya", "Sparta"),
                new White_1.Participant("Vadim", "Sparta"),
                new White_1.Participant("Marat", "Meteor"),
                new White_1.Participant("Danil", "Gorniy"),
                new White_1.Participant("Roma", "Gorniy"),
                new White_1.Participant("Egor", "Gorniy"),
                new White_1.Participant("Masha", "Dinamo"),
                new White_1.Participant("Dasha", "Dinamo")
            };
            foreach (var item in participants)
            {
                item.Jump(Math.Round(_rand.NextDouble() * 10, 2));
                item.Jump(Math.Round(_rand.NextDouble() * 10, 2));
            }
            return participants;
        }
        private White_2.Participant[] Create_White2_Array()
        {
            var participants = new White_2.Participant[10]
            {
                new White_2.Participant("Vasya", "Petrovich"),
                new White_2.Participant("Petya", "Nikolayevich"),
                new White_2.Participant("Kolya", "Vadimovich"),
                new White_2.Participant("Vadim", "Maratovich"),
                new White_2.Participant("Marat", "Danilovich"),
                new White_2.Participant("Danil", "Romanovich"),
                new White_2.Participant("Roma", "Egorovich"),
                new White_2.Participant("Egor", "Vasiliyevich"),
                new White_2.Participant("Masha", "Nikolayevna"),
                new White_2.Participant("Dasha", "Vadimovna")
            };
            foreach (var item in participants)
            {
                item.Jump(Math.Round(_rand.NextDouble() * 10, 2));
                item.Jump(Math.Round(_rand.NextDouble() * 10, 2));
            }
            return participants;
        }
        private White_3.Student[] Create_White3_Array()
        {
            var participants = new White_3.Student[10]
            {
                new White_3.Student("Vasya", "Petrovich"),
                new White_3.Student("Petya", "Nikolayevich"),
                new White_3.Student("Kolya", "Vadimovich"),
                new White_3.Student("Vadim", "Maratovich"),
                new White_3.Student("Marat", "Danilovich"),
                new White_3.Undergraduate("Danil", "Romanovich"),
                new White_3.Undergraduate("Roma", "Egorovich"),
                new White_3.Undergraduate("Egor", "Vasiliyevich"),
                new White_3.Undergraduate("Masha", "Nikolayevna"),
                new White_3.Undergraduate("Dasha", "Vadimovna")
            };
            foreach (var item in participants)
            {
                for (global::System.Int32 i = 0; i < 10; i++)
                {
                    var mark = _rand.Next(0, 6);
                    item.Lesson(mark > 1 ? mark : 0);
                }
            }
            return participants;
        }
        private White_4.Human[] Create_White4_Array()
        {
            var participants = new White_4.Human[10]
            {
                new White_4.Human("Vasya", "Petrovich"),
                new White_4.Human("Petya", "Nikolayevich"),
                new White_4.Human("Kolya", "Vadimovich"),
                new White_4.Human("Vadim", "Maratovich"),
                new White_4.Human("Marat", "Danilovich"),
                new White_4.Participant("Danil", "Romanovich"),
                new White_4.Participant("Roma", "Egorovich"),
                new White_4.Participant("Egor", "Vasiliyevich"),
                new White_4.Participant("Masha", "Nikolayevna"),
                new White_4.Participant("Dasha", "Vadimovna")
            };
            foreach (var item in participants)
            {
                if (item is White_4.Participant partic)
                {
                    for (global::System.Int32 i = 0; i < 10; i++)
                    {
                        partic.PlayMatch(Math.Round(_rand.NextDouble() * 10, 2));
                        partic.PlayMatch(Math.Round(_rand.NextDouble() * 10, 2));
                    }                
                }
            }
            return participants;
        }
        private White_5.Team[] Create_White5_Array()
        {
            var participants = new White_5.Team[10]
            {
                new White_5.ManTeam("CSKA"),
                new White_5.ManTeam("Sparta"),
                new White_5.ManTeam("Meteor"),
                new White_5.ManTeam("Gorniy"),
                new White_5.ManTeam("Dinamo"),
                new White_5.WomanTeam("Bars"),
                new White_5.WomanTeam("Unics"),
                new White_5.WomanTeam("Tracktor"),
                new White_5.WomanTeam("Bulls"),
                new White_5.WomanTeam("Chikago")
            };
            foreach (var item in participants)
            {
                for (global::System.Int32 i = 0; i < 10; i++)
                {
                    item.PlayMatch(_rand.Next(0, 5), _rand.Next(0, 5));
                }
            }
            return participants;
        }
        private void Check(White_1.Participant[] original, White_1.Participant[] restored)
        {
            Assert.AreEqual(original.Length, restored.Length);
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == null)
                {
                    Assert.IsNull(restored[i]);
                    continue;
                }
                Assert.AreEqual(original[i].Surname, restored[i].Surname);
                Assert.AreEqual(original[i].Club, restored[i].Club);
                Assert.AreEqual(original[i].FirstJump, restored[i].FirstJump, 0.0001);
                Assert.AreEqual(original[i].SecondJump, restored[i].SecondJump, 0.0001);
                Assert.AreEqual(original[i].JumpSum, restored[i].JumpSum, 0.0001);
            }
        }
        private void Check(White_2.Participant[] original, White_2.Participant[] restored)
        {
            Assert.AreEqual(original.Length, restored.Length);
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == null)
                {
                    Assert.IsNull(restored[i]);
                    continue;
                }
                Assert.AreEqual(original[i].Name, restored[i].Name);
                Assert.AreEqual(original[i].Surname, restored[i].Surname);
                Assert.AreEqual(original[i].FirstJump, restored[i].FirstJump, 0.0001);
                Assert.AreEqual(original[i].SecondJump, restored[i].SecondJump, 0.0001);
                Assert.AreEqual(original[i].BestJump, restored[i].BestJump, 0.0001);
            }
        }
        private void Check(White_3.Student[] original, White_3.Student[] restored)
        {
            Assert.AreEqual(original.Length, restored.Length);
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == null)
                {
                    Assert.IsNull(restored[i]);
                    continue;
                }
                Assert.AreEqual(original[i].Name, restored[i].Name);
                Assert.AreEqual(original[i].Surname, restored[i].Surname);
                Assert.AreEqual(original[i].AvgMark, restored[i].AvgMark, 0.0001);
                Assert.AreEqual(original[i].Skipped, restored[i].Skipped);
            }
        }
        private void Check(White_4.Human[] original, White_4.Human[] restored)
        {
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == null)
                {
                    Assert.IsNull(restored[i]);
                    continue;
                }
                Assert.AreEqual(original[i].Name, restored[i].Name);
                Assert.AreEqual(original[i].Surname, restored[i].Surname);
                if (original[i] is White_4.Participant or)
                {
                    Assert.IsTrue(restored[i] is White_4.Participant);
                    var re = restored[i] as White_4.Participant;
                    Assert.AreEqual(or.Scores.Length, re.Scores.Length);
                    for (int j = 0; j < or.Scores.Length; j++)
                    {
                        Assert.AreEqual(or.Scores[j], re.Scores[j], 0.0001);
                    }
                    Assert.AreEqual(or.TotalScore, re.TotalScore, 0.0001);
                }
            }
        }
        private void Check(White_5.Match[] original, White_5.Match[] restored)
        {
            Assert.AreEqual(original.Length, restored.Length);
            for (int i = 0; i < original.Length; i++)
            {
                Assert.AreEqual(original[i].Goals, restored[i].Goals);
                Assert.AreEqual(original[i].Misses, restored[i].Misses);
                Assert.AreEqual(original[i].Difference, restored[i].Difference);
                Assert.AreEqual(original[i].Score, restored[i].Score);
            }
        }
        private void Check(White_5.Team[] original, White_5.Team[] restored)
        {
            Assert.AreEqual(original.Length, restored.Length);
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == null)
                {
                    Assert.IsNull(restored[i]);
                    continue;
                }
                Assert.AreEqual(original[i].Name, restored[i].Name);
                Assert.AreEqual(original[i].TotalDifference, restored[i].TotalDifference);
                Assert.AreEqual(original[i].TotalScore, restored[i].TotalScore);
                if (original[i].Matches == null)
                {
                    Assert.IsNull(restored[i].Matches);
                }
                else
                {
                    Check(original[i].Matches, restored[i].Matches);
                }
                if (original[i] is White_5.ManTeam orig)
                {
                    Assert.IsTrue(restored[i] is White_5.ManTeam);
                    var rest = restored[i] as White_5.ManTeam;
                    Assert.AreEqual(orig.Derby == null, rest.Derby == null);
                }
                else if (original[i] is White_5.WomanTeam or)
                {
                    Assert.IsTrue(restored[i] is White_5.WomanTeam);
                    var re = restored[i] as White_5.WomanTeam;
                    Assert.AreEqual(or.Penalties.Length, re.Penalties.Length);
                    for (int j = 0; j < or.Penalties.Length; j++)
                    {
                        Assert.AreEqual(or.Penalties[j], re.Penalties[j], 0.0001);
                    }
                    Assert.AreEqual(or.TotalPenalties, re.TotalPenalties, 0.0001);
                }
            }
        }
    }
}
