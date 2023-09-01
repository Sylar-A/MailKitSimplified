﻿using MailKit;
using MimeKit;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MailKitSimplified.Receiver.Abstractions
{
    public interface IMailFolderReader : IMailReader, IAsyncDisposable, IDisposable
    {
        /// <summary>
        /// Get message summaries with just the requested items filled in for the specified unique IDs.
        /// </summary>
        /// <param name="uniqueIds">Messages to download by <see cref="UniqueId">ID</see>.</param>
        /// <param name="filter"><see cref="MessageSummaryItems"/> to download.</param>
        /// <param name="cancellationToken">Request cancellation token.</param>
        /// <returns>Collection of <see cref="IMessageSummary"/> items.</returns>
        Task<IList<IMessageSummary>> GetMessageSummariesAsync(IEnumerable<UniqueId> uniqueIds, MessageSummaryItems filter = MessageSummaryItems.UniqueId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a <see cref="MimeMessage"/> by unique ID.
        /// </summary>
        /// <param name="uniqueId">Message to download by <see cref="UniqueId">ID</see>.</param>
        /// <param name="cancellationToken">Request cancellation token.</param>
        /// <param name="progress">The progress reporting mechanism.</param>
        /// <returns>Downloaded <see cref="MimeMessage"/>.</returns>
        Task<MimeMessage> GetMimeMessageAsync(UniqueId uniqueId, CancellationToken cancellationToken = default, ITransferProgress progress = null);

        /// <summary>
        /// Get <see cref="MimeMessage"/>s by their unique IDs.
        /// </summary>
        /// <param name="uniqueIds">Messages to download by <see cref="UniqueId">ID</see>.</param>
        /// <param name="cancellationToken">Request cancellation token.</param>
        /// <param name="progress">The progress reporting mechanism.</param>
        /// <returns>List of <see cref="MimeMessage"/> items.</returns>
        Task<IList<MimeMessage>> GetMimeMessagesAsync(IEnumerable<UniqueId> uniqueIds, CancellationToken cancellationToken = default, ITransferProgress progress = null);
    }
}
