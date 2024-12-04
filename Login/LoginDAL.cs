using System;
using System.Collections.Generic;
using System.IO;

namespace POO_25453_TP.DAL
{
    public static class Login
    {
        public static bool ValidateClientLogin(string username, string password)
        {
            // Use the absolute path directly
            string filePath = @"C:\PROGRAM_CS\25453_TP_POO\Client\clients.txt";
            return ValidateCredentials(username, password, filePath);
        }

        public static bool ValidateAccountLogin(string username, string password)
        {
            // Use the absolute path directly
            string filePath = @"C:\PROGRAM_CS\25453_TP_POO\Account\accounts.txt";
            return ValidateCredentials(username, password, filePath);
        }

        private static bool ValidateCredentials(string username, string password, string filePath)
        {
            // Verifica se o arquivo existe
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Arquivo de credenciais não encontrado: {filePath}");
            }

            // Lê todas as linhas do arquivo
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                // Divide a linha em partes (assumindo ',' como delimitador)
                var parts = line.Split(',');

                // Verifica se o arquivo é de contas ou clientes
                if (filePath.Contains("accounts"))
                {
                    // Formato para contas: username,password,name
                    if (parts.Length >= 3 && parts[0] == username && parts[1] == password)
                    {
                        return true; // Credenciais de conta válidas
                    }
                }
                else if (filePath.Contains("clients"))
                {
                    // Formato para clientes: clientID,username,password,name,email,phone,address,city,region,postalCode
                    if (parts.Length >= 10 && parts[1] == username && parts[2] == password)
                    {
                        return true; // Credenciais de cliente válidas
                    }
                }
            }

            // Nenhuma correspondência encontrada
            return false;
        }


    }
}
