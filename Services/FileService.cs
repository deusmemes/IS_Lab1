using System;
using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Services
{
    public class FileService
    {
        private readonly DES _des;
        private const string Key = "secret";
        private static Random _rnd;

        public FileService()
        {
            _rnd = new Random();

            _des = DES.Create();

            var random = RandomString(2);
            var bytes = Encoding.ASCII.GetBytes(Key + "tt");

            _des.Key = bytes;
            _des.IV = bytes;

            Init();
        }

        private void Init()
        {
            if (!File.Exists(FilePathsEnum.MAIN))
            {
                var adminUser = new User
                {
                    Name = "ADMIN",
                    Password = HashService.Md4Hash(""),
                    Type = UserEnum.ADMIN,
                    IsBlocked = false,
                    PasswordRestriction = false
                };

                WriteDataToFile(new List<User> { adminUser }, FilePathsEnum.MAIN, true);
            }

            CreateTempFile();
        }

        public List<User> GetDataFromFile(string path, bool decrypt)
        {
            var json = decrypt ? Decrypt() : ReadJson(path);
            var users = JsonConvert.DeserializeObject<List<User>>(json);

            return users;
        }

        public void WriteDataToFile(List<User> data, string path, bool encrypt)
        {
            var json = JsonConvert.SerializeObject(data);
            if (encrypt)
            {
                Encrypt(json);
            }
            else
            {
                WriteJson(json, path);
            }
        }

        private string ReadJson(string path)
        {
            using var fs = new FileStream(path, FileMode.Open);
            using var sr = new StreamReader(fs);

            return sr.ReadLine();
        }

        private void WriteJson(string json, string path)
        {
            using var fs = new FileStream(path, FileMode.Open);
            using var wr = new StreamWriter(fs);

            wr.WriteLine(json);
        }

        private void CreateTempFile()
        {
            var json = Decrypt();

            using var fs = new FileStream(FilePathsEnum.TEMP, FileMode.OpenOrCreate);
            using var sw = new StreamWriter(fs);

            sw.WriteLine(json);
        }

        private void DeleteTempFile()
        {
            if (File.Exists(FilePathsEnum.TEMP))
            {
                File.Delete(FilePathsEnum.TEMP);
            }
        }

        private void Encrypt(string json)
        {
            var des = DES.Create();
            des.Mode = CipherMode.ECB;

            var fs = File.Open(FilePathsEnum.MAIN, FileMode.OpenOrCreate);
            using var cs = new CryptoStream(
                fs,
                des.CreateEncryptor(_des.Key, _des.IV),
                CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);

            sw.WriteLine(json);
        }

        private string Decrypt()
        {
            var des = DES.Create();
            des.Mode = CipherMode.ECB;

            using var fs = new FileStream(FilePathsEnum.MAIN, FileMode.Open);
            using var cs = new CryptoStream(
                fs,
                des.CreateDecryptor(_des.Key, _des.IV),
                CryptoStreamMode.Read);
            var streamReader = new StreamReader(cs);
            var input = streamReader.ReadLine();

            return input;
        }

        private void SaveData()
        {
            var users = Data.GetInstance().Users;
            WriteDataToFile(users, FilePathsEnum.MAIN, true);
        }

        private static string RandomString(int length)
        {
            return string.Join("", Enumerable.Range(0, length).Select(i => (char)_rnd.Next(97, 122)));
        }

        ~FileService()
        {
            SaveData();
            DeleteTempFile();
        }
    }
}
