﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MailKitSimplified.Sender.Abstractions
{
    public interface IFileHandler
    {
        Task<Stream> GetFileStreamAsync(string filePath, CancellationToken cancellationToken = default);
    }
}
