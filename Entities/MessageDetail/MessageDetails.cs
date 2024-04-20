using MimeKit;

namespace Entities.MessageDetail
{
    public class MessageDetails
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public MessageDetails(IEnumerable<string> to, string subject, string content, string receiverName)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(receiverName ,x)));
            Subject = subject;
            Content = content;
        }
    }
}
