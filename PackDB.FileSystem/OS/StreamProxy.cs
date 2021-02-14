﻿using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace PackDB.FileSystem.OS
{
    [ExcludeFromCodeCoverage]
    public class StreamProxy : IStream
    {
        private readonly FileStream _stream;

        public StreamProxy(FileStream stream)
        {
            _stream = stream;
        }

        public Stream GetStream()
        {
            return _stream;
        }

        public void Close()
        {
            _stream.Close();
        }

        public void Dispose()
        {
            _stream.Dispose();
        }
    }
}