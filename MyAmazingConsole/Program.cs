using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

var des = new DESCryptoServiceProvider(); // 🔥 Weak algorithm
des.GenerateKey();
des.GenerateIV();