﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


public class SecuredPasswordController
{
    private const int SaltByteSize = 24;
    private const int HashByteSize = 24;
    private const int HasingIterationsCount = 10101;

    public SecuredPasswordController()
    {

    }

    public string HashPassword(string password)
    {
        byte[] salt;
        byte[] buffer2;
        if (password == null)
        {
            throw new ArgumentNullException("password");
        }
        using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SaltByteSize, HasingIterationsCount))
        {
            salt = bytes.Salt;
            buffer2 = bytes.GetBytes(HashByteSize);
        }
        byte[] dst = new byte[(SaltByteSize + HashByteSize) + 1];
        Buffer.BlockCopy(salt, 0, dst, 1, SaltByteSize);
        Buffer.BlockCopy(buffer2, 0, dst, SaltByteSize + 1, HashByteSize);
        return Convert.ToBase64String(dst);
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        byte[] _passwordHashBytes;

        int _arrayLen = (SaltByteSize + HashByteSize) + 1;

        if (hashedPassword == null)
        {
            return false;
        }

        if (password == null)
        {
            throw new ArgumentNullException("password");
        }

        byte[] src = Convert.FromBase64String(hashedPassword);

        if ((src.Length != _arrayLen) || (src[0] != 0))
        {
            return false;
        }

        byte[] _currentSaltBytes = new byte[SaltByteSize];
        Buffer.BlockCopy(src, 1, _currentSaltBytes, 0, SaltByteSize);

        byte[] _currentHashBytes = new byte[HashByteSize];
        Buffer.BlockCopy(src, SaltByteSize + 1, _currentHashBytes, 0, HashByteSize);

        using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, _currentSaltBytes, HasingIterationsCount))
        {
            _passwordHashBytes = bytes.GetBytes(SaltByteSize);
        }

        return AreHashesEqual(_currentHashBytes, _passwordHashBytes);

    }

    private bool AreHashesEqual(byte[] firstHash, byte[] secondHash)
    {
        int _minHashLength = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
        var xor = firstHash.Length ^ secondHash.Length;
        for (int i = 0; i < _minHashLength; i++)
            xor |= firstHash[i] ^ secondHash[i];
        return 0 == xor;
    }

    /* Хреновина для получение МАС, чтобы сохранить в БД для юзера для "запомнить меня" верификации */
    public string GetMac()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
            if (sMacAddress == String.Empty)// only return MAC Address from first card  
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
        }
        return sMacAddress;
    }

    /* Метод для сверки Mac */
    public bool VerifyMac(string _storedMac)
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
            if (sMacAddress == String.Empty)// only return MAC Address from first card  
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
        }

        return (_storedMac == sMacAddress);
    }


    /* Генерируем хранимый токен */
    public int GenerateToken(int _token1, int _token2, int _salt)
    {
        return _token1 + _token2 + _salt;
    }

    /* Проверяем хранимый токен на соответсвие */
    public bool VerifyToken(int _storedToken, int _token1, int _token2, int _salt)
    {
        return _storedToken == _token1 + _token2 + _salt;
    }

}