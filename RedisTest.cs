using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class RedisTest
    {

        public static void Redisconnection(string connection)
        {
            var csredis = new CSRedis.CSRedisClient(connection);
            RedisHelper.Initialization(csredis);
        }


        IRedisClient _redisClient = new CustomerRedis();
        string userdataKey = "test";
        public async void SendVerifyCode(string phoneNumber)
        {
            //create random verify code

            await _redisClient.SetAsync(userdataKey, phoneNumber, 300);

            //send short message

        }

        public async Task<string> VerifyCode(string userdataKey)
        {

            var resultCode = await _redisClient.GetAsync(userdataKey);

            return resultCode;

        }
        //string操作
        public void RedisHelperStringTest()
        {
            var csredis = new CSRedis.CSRedisClient("192.168.1.99:6379");
            RedisHelper.Initialization(csredis);
            // 添加字符串键-值对
            csredis.Set("hello", "1");
            csredis.Set("world", "2");
            csredis.Set("hello", "3");

            // 根据键获取对应的值
            csredis.Get("hello");

            // 移除元素
            csredis.Del("world");

            //在对同一个键多次赋值时，该键的值是最后一次赋值时的值，实例中hello对应的值最终为3。
            /*    数值操作    */
            csredis.Set("num-key", "24");

            // value += 5
            csredis.IncrBy("num-key", 5);
            // output -> 29

            // value -= 10
            csredis.IncrBy("num-key", -10);
            // output -> 19
            /*    字节串操作    */
            csredis.Set("string-key", "hello ");

            // 在指定key的value末尾追加字符串
            csredis.Append("string-key", "world");
            // output -> "hello world"

            // 获取从指定范围所有字符构成的子串（start:3,end:7）
            csredis.GetRange("string-key", 3, 7);
            // output ->  "lo wo"

            // 用新字符串从指定位置覆写原value（index:4）
            csredis.SetRange("string-key", 4, "aa");
            // output -> "hellaaword"

            //对字节串进行自增、自减操作时，redis会报错。
            //使用Append、SetRange方法对value进行写入时，字节串的长度可能不够用，这时redis会使用空字符(null)将value扩充到指定长度，然后再进行写入操作。

        }

        //list操作
        public void RedisHelperListTest()
        {
            var csredis = new CSRedis.CSRedisClient("192.168.1.99:6379");
            RedisHelper.Initialization(csredis);
            // 从右端推入元素
            csredis.RPush("my-list", "item1", "item2", "item3", "item4");
            // 从右端弹出元素
            csredis.RPop("my-list");
            // 从左端推入元素
            csredis.LPush("my-list", "LeftPushItem");
            // 从左端弹出元素
            csredis.LPop("my-list");

            // 遍历链表元素（start:0,end:-1即可返回所有元素）
            foreach (var item in csredis.LRange("my-list", 0, -1))
            {
                Console.WriteLine(item);
            }
            // 按索引值获取元素（当索引值大于链表长度，返回空值，不会报错）
            Console.WriteLine($"{csredis.LIndex("my-list", 1)}");

            // 修剪指定范围内的元素（start:4,end:10）
            csredis.LTrim("my-list", 4, 10);
            //除了对列表中的元素进行以上简单的处理之外，还可以将一个列表中的元素复制到另一个列表中。在语义上，列表的左端默认为“头部”，列表的右端为“尾部”。

            // 将my-list最后一个元素弹出并压入another-list的头部
            csredis.RPopLPush("my-list", "another-list");
        }
        //Set操作
        //集合以无序的方式存储各不相同的元素，也就是说在集合中的每个元素的Key都不重复。在redis中可以快速地对集合执行添加、移除等操作。
        public void RedisHelperSetTest()
        {
            var csredis = new CSRedis.CSRedisClient("192.168.1.99:6379");
            RedisHelper.Initialization(csredis);
            // 实际上只插入了两个元素("item1","item2")
            csredis.SAdd("my-set", "item1", "item1", "item2");

            // 集合的遍历
            foreach (var members in csredis.SMembers("my-set"))
            {
                Console.WriteLine($"集合成员：{members.ToString()}");
            }

            // 判断元素是否存在
            string member = "item1";
            Console.WriteLine($"{member}是否存在:{csredis.SIsMember("my-set", member)}");
            // output -> True

            // 移除元素
            csredis.SRem("my-set", member);
            Console.WriteLine($"{member}是否存在:{csredis.SIsMember("my-set", member)}");
            // output ->  False

            // 随机移除一个元素
            csredis.SPop("my-set");
            //以上是对一个集合中的元素进行操作，除此之外还可以对两个集合进行交、并、差操作
            csredis.SAdd("set-a", "item1", "item2", "item3", "item4", "item5");
            csredis.SAdd("set-b", "item2", "item5", "item6", "item7");

            // 差集
            csredis.SDiff("set-a", "set-b");
            // output -> "item1", "item3","item4"

            // 交集
            csredis.SInter("set-a", "set-b");
            // output -> "item2","item5"

            // 并集
            csredis.SUnion("set-a", "set-b");
            // output -> "item1","item2","item3","item4","item5","item6","item7"

            //另外还可以用SDiffStore,SInterStore,SUnionStore将操作后的结果存储在新的集合中。

        }
        //散列(hashmap)
        public void RedisHelperHashTest()
        {
            var csredis = new CSRedis.CSRedisClient("192.168.1.99:6379");
            RedisHelper.Initialization(csredis);
            //在redis中我们可以使用散列将多个键 - 值对存储在一个redis键上，从而达到将一系列相关数据存放在一起的目的。例如添加一个redis键Article: 1001,然后在这个键中存放ID为1001的文章的标题、作者、链接、点赞数等信息。我们可以把这样数据集看作是关系数据库中的行。
            // 向散列添加元素
            csredis.HSet("ArticleID:10001", "Title", "了解简单的Redis数据结构");
            csredis.HSet("ArticleID:10001", "Author", "xscape");
            csredis.HSet("ArticleID:10001", "PublishTime", "2019-01-01");

            // 根据Key获取散列中的元素
            csredis.HGet("ArticleID:10001", "Title");

            // 获取散列中的所有元素
            foreach (var item in csredis.HGetAll("ArticleID:10001"))
            {
                Console.WriteLine(item.Value);
            }
            //HGet和HSet方法执行一次只能处理一个键值对，而HMGet和HMSet是他们的多参数版本，一次可以处理多个键值对。
            var keys = new string[] { "Title", "Author", "publishTime" };
            csredis.HMGet("ID:10001", keys);
            //虽然使用HGetAll可以取出所有的value，但是有时候散列包含的值可能非常大，容易造成服务器的堵塞，为了避免这种情况，我们可以使用HKeys取到散列的所有键(HVals可以取出所有值)，然后再使用HGet方法一个一个地取出键对应的值。
            foreach (var item in csredis.HKeys("ID:10001"))
            {
                Console.WriteLine($"{item} - {csredis.HGet("ID:10001", item)}");
            }
            //和处理字符串一样，我们也可以对散列中的值进行自增、自减操作，原理同字符串是一样的。
            csredis.HSet("ArticleID:10001", "votes", "257");
            csredis.HIncrBy("ID:10001", "votes", 40);
            // output -> 297
        }

        //有序集合
        //有序集合可以看作是可排序的散列，不过有序集合的val成为score分值，集合内的元素就是基于score进行排序的，score以双精度浮点数的格式存储。
        public void RedisHelperscoreTest()
        {
            var csredis = new CSRedis.CSRedisClient("192.168.1.99:6379");
            RedisHelper.Initialization(csredis);
            // 向有序集合添加元素
            csredis.ZAdd("Quiz", (79, "Math"));
            csredis.ZAdd("Quiz", (98, "English"));
            csredis.ZAdd("Quiz", (87, "Algorithm"));
            csredis.ZAdd("Quiz", (84, "Database"));
            csredis.ZAdd("Quiz", (59, "Operation System"));

            //返回集合中的元素数量
            csredis.ZCard("Quiz");

            // 获取集合中指定范围(90~100)的元素集合
            csredis.ZRangeByScore("Quiz", 90, 100);

            // 获取集合所有元素并升序排序
            csredis.ZRangeWithScores("Quiz", 0, -1);

            // 移除集合中的元素
            csredis.ZRem("Quiz", "Math");

        }
        //设置key
        public void RedisKeyOver()
        {
            //redis还允许我们为key设置有效期，当key过期之后，key就不存在了。
            var csredis = new CSRedis.CSRedisClient("192.168.1.99:6379");
            RedisHelper.Initialization(csredis);
            csredis.Set("MyKey", "hello,world");
            Console.WriteLine(csredis.Get("MyKey"));
            // output -> "hello,world"

            csredis.Expire("MyKey", 5); // key在5秒后过期，也可以使用ExpireAt方法让它在指定时间自动过期

            Thread.Sleep(6000); // 线程暂停6秒
            Console.WriteLine(csredis.Get("MyKey"));
            // output -> ""
        }

       // 基本事务
       //事务可以保证一个客户端在执行多条命令时，不被其他客户端打断，这跟关系型数据库的事务是不一样的。事务需要使用MULTI和EXEC命令，redis会将被MULTI和EXEC所包围的代码依次执行，当该事务结束之后，redis才会处理其他客户端的命令。
       //管道(pipeline)
       //redis的事务是通过pipeline实现的，使用pipeline时，客户端会自动调用MULTI和EXEX命令，将多条命令打包并一次性地发送给redis，然后redis再将命令的执行结果全部打包并一次性返回给客户端，这样有效的减少了redis与客户端的通信次数，提升执行多次命令时的性能。
        public void Pipe()
        {


            var csredis = new CSRedis.CSRedisClient("192.168.1.99:6379");
            RedisHelper.Initialization(csredis);
            var pl = csredis.StartPipe();
            for (int i = 0; i < 10; i++)
            {
                csredis.IncrBy("key-one");
            }
            pl.EndPipe();
        }


    }
}
