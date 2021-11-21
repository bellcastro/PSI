using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace NutriMais.Migrations
{
    public partial class InitSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var user in getUserSeeds())
            {
                migrationBuilder.InsertData(
                  table: "AspNetUsers",
                  columns: new[] {"Id", "Discriminator", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed",
                         "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed",
                         "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "FullName", "SecurityStamp"},
                  values: new object[] { 
                      user["Id"],
                      user["Discriminator"],
                      user["UserName"],
                      user["NormalizedUserName"],
                      user["Email"],
                      user["NormalizedEmail"],
                      user["EmailConfirmed"],
                      user["PasswordHash"],
                      user["PhoneNumber"],
                      user["PhoneNumberConfirmed"],
                      user["TwoFactorEnabled"],
                      user["LockoutEnd"],
                      user["LockoutEnabled"],
                      user["AccessFailedCount"],
                      user["FullName"],
                      user["SecurityStamp"],
                  }
                );
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }

        private Dictionary<String, object>[] getUserSeeds()
        {
            return new Dictionary<String, object>[]
            {
                new Dictionary<string, object> (){
                    {"Id", "1"},
                    {"Discriminator", "UserModel"},
                    {"UserName","john1@example.com"}, 
                    {"FullName","Arthur Fernandes"},
                    {"NormalizedUserName", "JOHN1@EXAMPLE.COM"},
                    {"Email", "john1@example.com"},
                    {"NormalizedEmail", "JOHN1@EXAMPLE.COM"},
                    {"EmailConfirmed", true},
                    {"PasswordHash", "AQAAAAEAACcQAAAAEOJgSPj+AJa2Fab4qjM+rNtDfEOhKEP4NCgJZ7dI5E+DlHXZLHfgCdVhxaloPVK3Zw=="}, //123456
                    {"PhoneNumber", "31 99999999"}, 
                    {"PhoneNumberConfirmed", true},
                    {"TwoFactorEnabled",  false}, 
                    {"LockoutEnd", null}, 
                    {"LockoutEnabled",  false},
                    {"SecurityStamp",  "UNULGBJAMMZ4D3ROMKPBFQOV5KON3LND"},
                    {"AccessFailedCount", 0}
                },
                 new Dictionary<string, object> (){
                    {"Id", "2"},
                    {"Discriminator", "UserModel"},
                    {"UserName","john2@example.com"},
                    {"FullName","Guilherme Ventura"},
                    {"NormalizedUserName", "JOHN2@EXAMPLE.COM"},
                    {"Email", "john2@example.com"},
                    {"NormalizedEmail", "JOHN2@EXAMPLE.COM"},
                    {"EmailConfirmed", true},
                    {"PasswordHash", "AQAAAAEAACcQAAAAEOJgSPj+AJa2Fab4qjM+rNtDfEOhKEP4NCgJZ7dI5E+DlHXZLHfgCdVhxaloPVK3Zw=="}, //123456
                    {"PhoneNumber", "31 99999999"},
                    {"PhoneNumberConfirmed", true},
                    {"TwoFactorEnabled",  false},
                    {"LockoutEnd", null},
                    {"LockoutEnabled",  false},
                    {"SecurityStamp",  "UNULGBJAMMZ4D3ROMKPBFQOV5KON3LND"},
                    {"AccessFailedCount", 0}
                },
                 new Dictionary<string, object> (){
                    {"Id", "3"},
                    {"Discriminator", "UserModel"},
                    {"UserName","john3@example.com"},
                    {"FullName","Rafael Freitas"},
                    {"NormalizedUserName", "JOHN3@EXAMPLE.COM"},
                    {"Email", "john3@example.com"},
                    {"NormalizedEmail", "JOHN3@EXAMPLE.COM"},
                    {"EmailConfirmed", true},
                    {"PasswordHash", "AQAAAAEAACcQAAAAEOJgSPj+AJa2Fab4qjM+rNtDfEOhKEP4NCgJZ7dI5E+DlHXZLHfgCdVhxaloPVK3Zw=="}, //123456
                    {"PhoneNumber", "31 99999999"},
                    {"PhoneNumberConfirmed", true},
                    {"TwoFactorEnabled",  false},
                    {"LockoutEnd", null},
                    {"LockoutEnabled",  false},
                    {"SecurityStamp",  "UNULGBJAMMZ4D3ROMKPBFQOV5KON3LND"},
                    {"AccessFailedCount", 0}
                },
                new Dictionary<string, object> (){
                    {"Id", "4"},
                    {"Discriminator", "UserModel"},
                    {"UserName","john4@example.com"},
                    {"FullName","Isabella Pimenta"},
                    {"NormalizedUserName", "JOHN4@EXAMPLE.COM"},
                    {"Email", "john4@example.com"},
                    {"NormalizedEmail", "JOHN4@EXAMPLE.COM"},
                    {"EmailConfirmed", true},
                    {"PasswordHash", "AQAAAAEAACcQAAAAEOJgSPj+AJa2Fab4qjM+rNtDfEOhKEP4NCgJZ7dI5E+DlHXZLHfgCdVhxaloPVK3Zw=="}, //123456
                    {"PhoneNumber", "31 99999999"},
                    {"PhoneNumberConfirmed", true},
                    {"TwoFactorEnabled",  false},
                    {"LockoutEnd", null},
                    {"LockoutEnabled",  false},
                    {"SecurityStamp",  "UNULGBJAMMZ4D3ROMKPBFQOV5KON3LND"},
                    {"AccessFailedCount", 0}
                },
                new Dictionary<string, object> (){
                    {"Id", "5"},
                    {"Discriminator", "UserModel"},
                    {"UserName","john5@example.com"},
                    {"NormalizedUserName", "JOHN5@EXAMPLE.COM"},
                    {"FullName","Maria Fernandes"},
                    {"Email", "john5@example.com"},
                    {"NormalizedEmail", "JOHN5@EXAMPLE.COM"},
                    {"EmailConfirmed", true},
                    {"PasswordHash", "AQAAAAEAACcQAAAAEOJgSPj+AJa2Fab4qjM+rNtDfEOhKEP4NCgJZ7dI5E+DlHXZLHfgCdVhxaloPVK3Zw=="}, //123456
                    {"PhoneNumber", "31 99999999"},
                    {"PhoneNumberConfirmed", true},
                    {"TwoFactorEnabled",  false},
                    {"LockoutEnd", null},
                    {"LockoutEnabled",  false},
                    {"SecurityStamp",  "UNULGBJAMMZ4D3ROMKPBFQOV5KON3LND"},
                    {"AccessFailedCount", 0}
                },
            };
        }
    }
}
