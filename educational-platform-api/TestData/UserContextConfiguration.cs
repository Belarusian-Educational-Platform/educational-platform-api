using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using educational_platform_api.Models;

namespace educational_platform_api.TestData
{
    public class UserContextConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasData(
                new User
                {
                    Id = 1,
                    Name = "Ulyana",
                    BirthDay = new DateTime(2004, 11, 25),
                    Email = "hotjames4u@quebecstart.com",
                    Password = "c314f4175f37c58d3cf3ebcc1354f27936956799\r\ndfb88b6a86fa62816b4197ea89a9bfcf19d70f6d\r\nd52d8f2c93edd0760e6d3b03fb35bab54c5d8012\r\n68094311133aee75ace503a9f9fa431336a705dc\r\n2eaa00717f9b0b15afceed4816ae5b963185a308\r\n00f609cb941ae5ef70636d441eeaf595f4822100\r\n21d87a71d5ca5da6e27941930f6d4d58c6c452d6\r\n7927179eb3d67cf2b303c6d1fbba1b5ce1aa3a03\r\n8443cb5ea9ac8c1bfcdd9cc88e3098366d69f861\r\n2729a8ae12d4f56d111ac45dd46cc8359489eded",
                    MobilePhone = "+375 29 403-72-60",
                    Role = "Student",
                    Positions = "{\r\n  \"positions\": [\r\n    {\r\n " +
                    "     \"name\": \"position1\"\r\n    },\r\n    {\r\n   " +
                    "   \"name\": \"position2\"\r\n    },\r\n    {\r\n     " +
                    " \"name\": \"position3\"\r\n    }\r\n  ]\r\n}",
                    OrganizationId = 1
                },
                new User
                {
                    Id = 2,
                    Name = "Alina",
                    BirthDay = new DateTime(2010, 7, 21),
                    Email = "reiianx@gasss.net",
                    Password = "bb3ef1330e074fbcbb40ecfd966fb80bd6db134f\r\na265c6a9fe903d97d1c79b34b0fa4d6fcb7aa004\r\naafecc145d8f570a52b905b6e8cb106cb0b6ff42\r\n80ef1cb60bec073b85b08fb2373550e16eb49c3e\r\n62e24598e331e1ff2028647a05ff60285d30f67b\r\nc0005dffad542181a466d641bf75ad15addb0b06\r\n08703c82d3f7fe874c05fec46edbf402f1125fa3\r\n479f808d4467e09b2069ca792a0437d2e0c28b97\r\nc10c4a93a03da1459ba6c182d0a600fddf13c252\r\n41d83b92db887d88a4ce48d22e6ed9d5d4b85fc0",
                    MobilePhone = "+375 44 164-23-69",
                    Role = "Student",
                    Positions = "{\r\n  \"positions\": [\r\n    {\r\n " +
                    "     \"name\": \"position1\"\r\n    },\r\n    {\r\n   " +
                    "   \"name\": \"position2\"\r\n    },\r\n    {\r\n     " +
                    " \"name\": \"position3\"\r\n    }\r\n  ]\r\n}",
                    OrganizationId = 1
                },
                new User
                {
                    Id = 3,
                    Name = "Aleh",
                    BirthDay = new DateTime(1990, 1, 24),
                    Email = "kxarmark@cbdnut.net",
                    Password = "70ba7cf8491b1eb5fc20c37ac7fc82e94938579b\r\n7f4b1244cd0ba03a1ba779a6d0d19555b7b94d1a\r\n23204011872721e1f2a580cac6d25cf035b97a0c\r\nc45275cc608da847f80f141e8e2297909cb255c9\r\n3e488f330559926297a4a624274cee8dd8774ff0\r\n18f89b02557294f372b45e75e0892c39f23cba98\r\n27c3045b28e88ff4d3f805aea169dda91161fcfe\r\n67b40abda4cc2eecd527267fd1013e20369c0396\r\n181a16931954145401a73413f64f148e7fd5a910\r\nfe7aa78e2294649890a83fba37f5b45062d35cea",
                    MobilePhone = "+375 29 352-28-10",
                    Role = "Teacher",
                    Positions = "{\r\n  \"positions\": [\r\n    {\r\n " +
                    "     \"name\": \"position1\"\r\n    },\r\n    {\r\n   " +
                    "   \"name\": \"position2\"\r\n    },\r\n    {\r\n     " +
                    " \"name\": \"position3\"\r\n    }\r\n  ]\r\n}",
                    OrganizationId = 1
                },
                new User
                {
                    Id = 4,
                    Name = "Hienadz",
                    BirthDay = new DateTime(2008, 6, 20),
                    Email = "imamikonyan@sannyfeina.art",
                    Password = "5ff69f238fe9b98bbd0859ce3dc2a621530ff211\r\n512361023410d8d516e8efd007ae6c6c68da0747\r\n83c170029e0d47b5105c7b75a73593ef55cf0162\r\n969ea2ad27c1deab0c931c9fe9b31f9adc8ab7b6\r\n1ee0624cb1af28d9c6d2d31c661712b2cf3c7d6e\r\n30d61a93722a8f0df300add4e5f3ad61f2abe638\r\n21ba6ec6a3bf3a0b5e394329815c85537e6e10c0\r\na7621e19b8f87d60fe097486899977f0846e64ce\r\ne25db6a402f5aa0bf11d76e842fdb092341237c0\r\n8025ae3e973c165822b980a4e6a6aa216641f9a7",
                    MobilePhone = "+375 33 938-46-86",
                    Role = "Student",
                    Positions = "{\r\n  \"positions\": [\r\n    {\r\n " +
                    "     \"name\": \"position1\"\r\n    },\r\n    {\r\n   " +
                    "   \"name\": \"position2\"\r\n    },\r\n    {\r\n     " +
                    " \"name\": \"position3\"\r\n    }\r\n  ]\r\n}",
                    OrganizationId = 2
                },
                new User
                {
                    Id = 5,
                    Name = "Nikita",
                    BirthDay = new DateTime(1975, 4, 2),
                    Email = "franicomunication@gmisow.com",
                    Password = "6db08d39f166bad76affc663a26aff98754bd927\r\n97aed667303b51c6bbade48526ddd16928ee48b8\r\n7367bd3c2da54a1e20796132ba49c9e99b183c89\r\n781bcae026f3b6366f478d19260d577ff9935855\r\nf8dfcacb8a74ddb3da34f43c3edb0358accc957a\r\n1fec727eb292f8dcb87e1a6a4d8c1a9bdd2012b3\r\n89b4e7640394c648b1ec3459a3c91ad338239f59\r\n728e8472c7d183ddc2a1bedccaa9d022bb161592\r\n10fef89ce84a4543928b97ebb212576933700637\r\nc1d777a21bc5203efcaae07e87669f071941a040",
                    MobilePhone = "+375 29 609-07-74",
                    Role = "Teacher",
                    Positions = "{\r\n  \"positions\": [\r\n    {\r\n " +
                    "     \"name\": \"position1\"\r\n    },\r\n    {\r\n   " +
                    "   \"name\": \"position2\"\r\n    },\r\n    {\r\n     " +
                    " \"name\": \"position3\"\r\n    }\r\n  ]\r\n}",
                    OrganizationId = 2
                },
                new User
                {
                    Id = 6,
                    Name = "Kseniya",
                    BirthDay = new DateTime(2011, 8, 5),
                    Email = "psylio@yagatekimi.com",
                    Password = "0383e2699bd8633b62a6ff264574781fde06282d\r\n398495443075d49583db2ebed15616710b69e801\r\n38bf2c128d263cd6c259c19623e677841777b054\r\nd5411439852c33165ba8469fdbf5f5eedd91bb32\r\nda071421b35f89251ff5b4ffef7c69ddb8248665\r\n0a672d0f6886a9883d0afe9aeab64e760a2f9643\r\n7dca856a7dbab157b3cbaaad6f88fdc32ab23348\r\nc96d35914210c1e4af319dfd91897be99551dae8\r\n73a433b641a52a260e7d000fe4cbac5c23646a4d\r\n611b53d404ce8a8f6015eb6ba0c962161e75fdf1",
                    MobilePhone = "+375 29 415-46-04",
                    Role = "Student",
                    Positions = "{\r\n  \"positions\": [\r\n    {\r\n " +
                    "     \"name\": \"position1\"\r\n    },\r\n    {\r\n   " +
                    "   \"name\": \"position2\"\r\n    },\r\n    {\r\n     " +
                    " \"name\": \"position3\"\r\n    }\r\n  ]\r\n}",
                    OrganizationId = 3
                },
                new User
                {
                    Id = 7,
                    Name = "Yuri",
                    BirthDay = new DateTime(1994, 8, 15),
                    Email = "zulu54@pankasyno23.com",
                    Password = "8af2346417d291a2855ef0c64a3526609e7c3011\r\nc405baeb06efbdab13b613383d7d35ab87e06f2f\r\n201ea0f3d5eb96ce825bf16c19f847e2a5230c77\r\nbb038e7cd6362854a29787e8127f51b338521c8c\r\n9ef5dcf12cbba3893f709dce05db588be70e60af\r\n8a51e466734fadadf985c4caba47d1ea8710d955\r\nfe4122fd800a9cb9d2eff25682d4f611332f94fa\r\n3255c824199aee1a2b22fb9cb75303bf998e1e1d\r\nb2be5a0cfa58d2fdee16b88f8df3c467e22b7af2\r\n1e5e6172ac2d68a142ffeda7c49a3dc3047b569f",
                    MobilePhone = "+375 29 865-01-63",
                    Role = "Teacher",
                    Positions = "{\r\n  \"positions\": [\r\n    {\r\n " +
                    "     \"name\": \"position1\"\r\n    },\r\n    {\r\n   " +
                    "   \"name\": \"position2\"\r\n    },\r\n    {\r\n     " +
                    " \"name\": \"position3\"\r\n    }\r\n  ]\r\n}",
                    OrganizationId = 3
                }
                );
        }
    }
}
