using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace penobotwithMongo.databasemodel
{
    internal class MongoModel
    {
        public string englishWord { get; set; }
        public string DiscordId;
        public string phenomenon;// 발음
        public string mean;  // 한글 뜻
        public void inital()
        { // Mongo DB를 위한 Connection String
            string connString = "mongodb://localhost:27017";

            // MongoClient 클라이언트 객체 생성
            MongoClient cli = new MongoClient(connString);

            // testdb 라는 데이타베이스 가져오기
            // 만약 해당 DB 없으면 Collection 생성시 새로 생성함
            IMongoDatabase testdb = cli.GetDatabase("penobot");

            // testdb 안에 Customers 라는 컬렉션(일종의 테이블)
            // 가져오기. 만약 없으면 새로 생성.
            var customers = testdb.GetCollection<Word>("word book");

            // INSERT - 컬렉션 객체의 Insert() 메서드 호출
            // Insert시 _id 라는 자동으로 ObjectID 생성 
            // 이 _id는 해당 다큐먼트는 나타는 키.
            Word cust1 = new Word { englishWord = "Kim", DiscordId = "ff" };
            customers.InsertOne(cust1);

            ObjectId id = cust1.Id;
        }
        public async Task Discordinital()
        { // Mongo DB를 위한 Connection String
            string connString = "mongodb://localhost:27017";

            // MongoClient 클라이언트 객체 생성
            MongoClient cli = new MongoClient(connString);

            // testdb 라는 데이타베이스 가져오기
            // 만약 해당 DB 없으면 Collection 생성시 새로 생성함
            IMongoDatabase testdb = cli.GetDatabase("penobot");

            // testdb 안에 Customers 라는 컬렉션(일종의 테이블)
            // 가져오기. 만약 없으면 새로 생성.
            var customers = testdb.GetCollection<Word>(this.DiscordId);

            // INSERT - 컬렉션 객체의 Insert() 메서드 호출
            // Insert시 _id 라는 자동으로 ObjectID 생성 
            // 이 _id는 해당 다큐먼트는 나타는 키.
            Word WordDocument = new Word
            {
                englishWord = this.englishWord,
                DiscordId = this.DiscordId,
                phenomenon = this.phenomenon,
                mean = this.mean
            };
            if (!(await customers.Find(i => i.englishWord == englishWord).AnyAsync()))
            {
                await customers.InsertOneAsync(WordDocument);
            }

            //await customers.ReplaceOneAsync(filter : new BsonDocument("englishWord",this.englishWord), options: new ReplaceOptions { IsUpsert = true }, replacement: WordDocument);

            ObjectId id = WordDocument.Id;
        }
        public List<Word> DiscordfindEnglish(string UserId)
        { // Mongo DB를 위한 Connection String
            string connString = "mongodb://localhost:27017";

            // MongoClient 클라이언트 객체 생성
            MongoClient cli = new MongoClient(connString);

            // testdb 라는 데이타베이스 가져오기
            // 만약 해당 DB 없으면 Collection 생성시 새로 생성함
            IMongoDatabase testdb = cli.GetDatabase("penobot");

            // testdb 안에 Customers 라는 컬렉션(일종의 테이블)
            // 가져오기. 만약 없으면 새로 생성.
            var customers = testdb.GetCollection<Word>(UserId);

            // INSERT - 컬렉션 객체의 Insert() 메서드 호출
            // Insert시 _id 라는 자동으로 ObjectID 생성 
            // 이 _id는 해당 다큐먼트는 나타는 키.
            var ouput = customers.Find(new BsonDocument()).ToList();

            return ouput;

        }
    }
}
class Word
{
    // 이 Id는 MongoDB Collection의 _id 컬럼과 매칭됨
    // (예외적인 Naming Convention)
    public ObjectId Id { get; set; }

    public string englishWord { get; set; }
    public string DiscordId;
    public string phenomenon = null!;// 발음
    public string mean = null!;  // 한글 뜻
}

