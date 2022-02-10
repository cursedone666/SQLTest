using System;
using Xunit;
using System.Collections.Generic;
using System.Data.SQLite;
using SQLHW;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void NecromancerAttributeTest()
        {
            
            SQLiteConnection database = DBRequestClass.DBConnect(@"Data Source = D:/SQLITE/SqlHW.db");
            SQLiteCommand command = DBRequestClass.CommandToDB("SELECT Attribute FROM Attributes WHERE AttributeId = (SELECT AttributeId FROM Classes WHERE MainSpell = 'Summon skeleton')", database);
            var exec = command.ExecuteScalar();
            Assert.Equal("Darkness", exec);
            DBRequestClass.CloseConnection(database);
        }

        [Fact]
        public void FullNameTest()
        {
            
            SQLiteConnection database = DBRequestClass.DBConnect(@"Data Source = D:/SQLITE/SqlHW.db");
            SQLiteCommand command = DBRequestClass.CommandToDB("SELECT FullName FROM Person Where ClassId = (SELECT ClassId From Classes WHERE Class = 'Archimage')", database);
            var exec = command.ExecuteScalar();
            Assert.Equal("Merlin Boba", exec);
            DBRequestClass.CloseConnection(database);

        }
        [Fact]
        public void SpellTest()
        {
             
            SQLiteConnection database = DBRequestClass.DBConnect(@"Data Source = D:/SQLITE/SqlHW.db");
            SQLiteCommand command = DBRequestClass.CommandToDB("SELECT MainSpell FROM Classes WHERE AttributeId = (SELECT AttributeId FROM Attributes WHERE Attribute = 'Fire')", database);
            var exec = command.ExecuteScalar();
            Assert.Equal("Fireball", exec.ToString());
            DBRequestClass.CloseConnection(database);
        }
        [Fact]
        public void ClassIDTest()
        {
            SQLiteConnection database = DBRequestClass.DBConnect(@"Data Source = D:/SQLITE/SqlHW.db");
            SQLiteCommand command = DBRequestClass.CommandToDB("SELECT ClassId From Classes WHERE AttributeId = (SELECT AttributeId FROM Attributes Where Attribute = 'Wind')", database);
            var exec = command.ExecuteScalar();
            Assert.Equal(5, Convert.ToInt64(exec));
            DBRequestClass.CloseConnection(database);
        }
        [Fact]
        public void PersonIDTest()
        {
            SQLiteConnection database = DBRequestClass.DBConnect(@"Data Source = D:/SQLITE/SqlHW.db");
            SQLiteCommand command = DBRequestClass.CommandToDB("SELECT Id From Person WHERE ClassId = (SELECT ClassId FROM Person Where FullName = 'Yarilo Bubnilo')", database);
            var exec = command.ExecuteScalar();
            Assert.Equal(4, Convert.ToInt64(exec));
            DBRequestClass.CloseConnection(database);
        }
    }
}
