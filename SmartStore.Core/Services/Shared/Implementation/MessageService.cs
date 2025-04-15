using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SmartStore.Core.Services.Shared.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartStore.Core.Services.Shared.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly Dictionary<string, string> _messages;

        public MessageService(IWebHostEnvironment env)
        {
            var filePath = Path.Combine(env.ContentRootPath, "Resources", "MessagesError.json");
            var json = File.ReadAllText(filePath);
            _messages = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }

        public string GetMessage(string key)
        {
            return _messages.ContainsKey(key) ? _messages[key] : "رسالة غير معرفة";
        }
    }

}
