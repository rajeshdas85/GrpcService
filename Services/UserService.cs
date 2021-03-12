using Grpc.Core;
using GrpcServiceDemo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceDemo
{
    public class UserService:Users.UsersBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<UsersReply> GetUsers(UsersRequest request, ServerCallContext context)
        {
            IEnumerable<User> users = Enumerable.Range(1, 10000).Select(
                x => new User { Id = x, Name = $"Name {x} from {request.DepartmentName}" });
            UsersReply response = new UsersReply();
            response.ListOfUsers.AddRange(users);
            return Task.FromResult(response);
        }
    }
}
