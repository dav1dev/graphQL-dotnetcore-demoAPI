using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GraphQLDemoAPI.Entities;

namespace GraphQLDemoAPI.Data
{
    public class InitialData
    {
        private readonly ApplicationDbContext _dbContext;

        public InitialData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            var hans = AddUserHans();
            var postsHans = AddPosts(hans, PostContentsHans);
            AddComments(hans, postsHans, CommentContentsHans);

            var fritz = AddUserFritz();
            var postsFritz = AddPosts(fritz, PostContentsFritz);
            AddComments(fritz, postsFritz, CommentContentsFritz);

            _dbContext.SaveChanges();
        }

        private User AddUserFritz() =>
            _dbContext.Users.Add(new User
            {
                Name = "Fritz Meier",
                Email = "fritz.meier@demo.org",
                UserName = "fritz.meier"
            }).Entity;

        private User AddUserHans() =>
            _dbContext.Users.Add(new User
            {
                Name = "Hans Fischer",
                Email = "hans.fischer@demo.org",
                UserName = "hans.fischer"
            }).Entity;

        private List<Post> AddPosts(User user, IEnumerable<(string title, string body)> posts) =>
            posts.Select(x => AddPost(user, x.title, x.body)).ToList();

        private Post AddPost(User user, string title, string body) =>
            _dbContext.Posts.Add(new Post
            {
                Title = title,
                Body = body,
                User = user
            }).Entity;

        private void AddComments(User user, IList<Post> posts, IEnumerable<string> comments)
        {
            var random = new Random();
            foreach (var comment in comments)
            {
                AddComment(user, posts[random.Next(posts.Count - 1)], comment);
            }
        }

        private void AddComment(User user, Post post, string body) =>
            _dbContext.Comments.Add(new Comment
            {
                Body = body,
                Post = post,
                User = user
            });

        /// <summary>
        /// Extracted from https://jsonplaceholder.typicode.com / https://github.com/typicode/jsonplaceholder
        /// License: MIT
        /// </summary>
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private static IEnumerable<(string title, string body)> PostContentsHans => new List<(string a, string b)>
        {
            (
                "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"),
            (
                "qui est esse",
                "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
            ),
            (
                "ea molestias quasi exercitationem repellat qui ipsa sit aut",
                "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut"
            ),
            (
                "eum et est occaecati",
                "ullam et saepe reiciendis voluptatem adipisci\nsit amet autem assumenda provident rerum culpa\nquis hic commodi nesciunt rem tenetur doloremque ipsam iure\nquis sunt voluptatem rerum illo velit"
            ),
            (
                "nesciunt quas odio",
                "repudiandae veniam quaerat sunt sed\nalias aut fugiat sit autem sed est\nvoluptatem omnis possimus esse voluptatibus quis\nest aut tenetur dolor neque"
            ),
            (
                "dolorem eum magni eos aperiam quia",
                "ut aspernatur corporis harum nihil quis provident sequi\nmollitia nobis aliquid molestiae\nperspiciatis et ea nemo ab reprehenderit accusantium quas\nvoluptate dolores velit et doloremque molestiae"
            ),
            (
                "magnam facilis autem",
                "dolore placeat quibusdam ea quo vitae\nmagni quis enim qui quis quo nemo aut saepe\nquidem repellat excepturi ut quia\nsunt ut sequi eos ea sed quas"
            ),
            (
                "dolorem dolore est ipsam",
                "dignissimos aperiam dolorem qui eum\nfacilis quibusdam animi sint suscipit qui sint possimus cum\nquaerat magni maiores excepturi\nipsam ut commodi dolor voluptatum modi aut vitae"
            )
        };

        /// <summary>
        /// Extracted from https://jsonplaceholder.typicode.com / https://github.com/typicode/jsonplaceholder
        /// License: MIT
        /// </summary>
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private static IEnumerable<(string title, string body)> PostContentsFritz => new List<(string a, string b)>
        {
            (
                "nesciunt iure omnis dolorem tempora et accusantium",
                "consectetur animi nesciunt iure dolore\nenim quia ad\nveniam autem ut quam aut nobis\net est aut quod aut provident voluptas autem voluptas"
            ),
            (
                "optio molestias id quia eum",
                "quo et expedita modi cum officia vel magni\ndoloribus qui repudiandae\nvero nisi sit\nquos veniam quod sed accusamus veritatis error"
            ),
            (
                "et ea vero quia laudantium autem",
                "delectus reiciendis molestiae occaecati non minima eveniet qui voluptatibus\naccusamus in eum beatae sit\nvel qui neque voluptates ut commodi qui incidunt\nut animi commodi"
            ),
            (
                "in quibusdam tempore odit est dolorem",
                "itaque id aut magnam\npraesentium quia et ea odit et ea voluptas et\nsapiente quia nihil amet occaecati quia id voluptatem\nincidunt ea est distinctio odio"
            ),
            (
                "dolorum ut in voluptas mollitia et saepe quo animi",
                "aut dicta possimus sint mollitia voluptas commodi quo doloremque\niste corrupti reiciendis voluptatem eius rerum\nsit cumque quod eligendi laborum minima\nperferendis recusandae assumenda consectetur porro architecto ipsum ipsam"
            ),
            (
                "voluptatem eligendi optio",
                "fuga et accusamus dolorum perferendis illo voluptas\nnon doloremque neque facere\nad qui dolorum molestiae beatae\nsed aut voluptas totam sit illum"
            ),
            (
                "eveniet quod temporibus",
                "reprehenderit quos placeat\nvelit minima officia dolores impedit repudiandae molestiae nam\nvoluptas recusandae quis delectus\nofficiis harum fugiat vitae"
            ),
            (
                "sint suscipit perspiciatis velit dolorum rerum ipsa laboriosam odio",
                "suscipit nam nisi quo aperiam aut\nasperiores eos fugit maiores voluptatibus quia\nvoluptatem quis ullam qui in alias quia est\nconsequatur magni mollitia accusamus ea nisi voluptate dicta"
            ),
            (
                "fugit voluptas sed molestias voluptatem provident",
                "eos voluptas et aut odit natus earum\naspernatur fuga molestiae ullam\ndeserunt ratione qui eos\nqui nihil ratione nemo velit ut aut id quo"
            ),
            (
                "voluptate et itaque vero tempora molestiae",
                "eveniet quo quis\nlaborum totam consequatur non dolor\nut et est repudiandae\nest voluptatem vel debitis et magnam"
            )
        };

        /// <summary>
        /// Extracted from https://jsonplaceholder.typicode.com / https://github.com/typicode/jsonplaceholder
        /// License: MIT
        /// </summary>
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private static IEnumerable<string> CommentContentsHans => new[]
        {
            "laudantium enim quasi est quidem magnam voluptate ipsam eos\ntempora quo necessitatibus\ndolor quam autem quasi\nreiciendis et nam sapiente accusantium",
            "est natus enim nihil est dolore omnis voluptatem numquam\net omnis occaecati quod ullam at\nvoluptatem error expedita pariatur\nnihil sint nostrum voluptatem reiciendis et",
            "quia molestiae reprehenderit quasi aspernatur\naut expedita occaecati aliquam eveniet laudantium\nomnis quibusdam delectus saepe quia accusamus maiores nam est\ncum et ducimus et vero voluptates excepturi deleniti ratione",
            "non et atque\noccaecati deserunt quas accusantium unde odit nobis qui voluptatem\nquia voluptas consequuntur itaque dolor\net qui rerum deleniti ut occaecati",
            "harum non quasi et ratione\ntempore iure ex voluptates in ratione\nharum architecto fugit inventore cupiditate\nvoluptates magni quo et",
            "doloribus at sed quis culpa deserunt consectetur qui praesentium\naccusamus fugiat dicta\nvoluptatem rerum ut voluptate autem\nvoluptatem repellendus aspernatur dolorem in",
            "maiores sed dolores similique labore et inventore et\nquasi temporibus esse sunt id et\neos voluptatem aliquam\naliquid ratione corporis molestiae mollitia quia et magnam dolor",
            "ut voluptatem corrupti velit\nad voluptatem maiores\net nisi velit vero accusamus maiores\nvoluptates quia aliquid ullam eaque",
            "sapiente assumenda molestiae atque\nadipisci laborum distinctio aperiam et ab ut omnis\net occaecati aspernatur odit sit rem expedita\nquas enim ipsam minus",
            "voluptate iusto quis nobis reprehenderit ipsum amet nulla\nquia quas dolores velit et non\naut quia necessitatibus\nnostrum quaerat nulla et accusamus nisi facilis",
            "ut dolorum nostrum id quia aut est\nfuga est inventore vel eligendi explicabo quis consectetur\naut occaecati repellat id natus quo est\nut blanditiis quia ut vel ut maiores ea",
            "expedita maiores dignissimos facilis\nipsum est rem est fugit velit sequi\neum odio dolores dolor totam\noccaecati ratione eius rem velit",
            "fuga eos qui dolor rerum\ninventore corporis exercitationem\ncorporis cupiditate et deserunt recusandae est sed quis culpa\neum maiores corporis et",
            "vel quae voluptas qui exercitationem\nvoluptatibus unde sed\nminima et qui ipsam aspernatur\nexpedita magnam laudantium et et quaerat ut qui dolorum",
            "nihil ut voluptates blanditiis autem odio dicta rerum\nquisquam saepe et est\nsunt quasi nemo laudantium deserunt\nmolestias tempora quo quia",
            "iste ut laborum aliquid velit facere itaque\nquo ut soluta dicta voluptate\nerror tempore aut et\nsequi reiciendis dignissimos expedita consequuntur libero sed fugiat facilis",
            "consequatur necessitatibus totam sed sit dolorum\nrecusandae quae odio excepturi voluptatum harum voluptas\nquisquam sit ad eveniet delectus\ndoloribus odio qui non labore",
            "veritatis voluptates necessitatibus maiores corrupti\nneque et exercitationem amet sit et\nullam velit sit magnam laborum\nmagni ut molestias",
            "doloribus est illo sed minima aperiam\nut dignissimos accusantium tempore atque et aut molestiae\nmagni ut accusamus voluptatem quos ut voluptates\nquisquam porro sed architecto ut",
            "qui harum consequatur fugiat\net eligendi perferendis at molestiae commodi ducimus\ndoloremque asperiores numquam qui\nut sit dignissimos reprehenderit tempore",
            "deleniti aut sed molestias explicabo\ncommodi odio ratione nesciunt\nvoluptate doloremque est\nnam autem error delectus",
            "qui ipsa animi nostrum praesentium voluptatibus odit\nqui non impedit cum qui nostrum aliquid fuga explicabo\nvoluptatem fugit earum voluptas exercitationem temporibus dignissimos distinctio\nesse inventore reprehenderit quidem ut incidunt nihil necessitatibus rerum",
            "voluptates provident repellendus iusto perspiciatis ex fugiat ut\nut dolor nam aliquid et expedita voluptate\nsunt vitae illo rerum in quos\nvel eligendi enim quae fugiat est",
            "repudiandae repellat quia\nsequi est dolore explicabo nihil et\net sit et\net praesentium iste atque asperiores tenetur",
            "sunt aut quae laboriosam sit ut impedit\nadipisci harum laborum totam deleniti voluptas odit rem ea\nnon iure distinctio ut velit doloribus\net non ex",
            "incidunt sapiente eaque dolor eos\nad est molestias\nquas sit et nihil exercitationem at cumque ullam\nnihil magnam et",
            "nisi vel quas ut laborum ratione\nrerum magni eum\nunde et voluptatem saepe\nvoluptas corporis modi amet ipsam eos saepe porro",
            "voluptatem repellendus quo alias at laudantium\nmollitia quidem esse\ntemporibus consequuntur vitae rerum illum\nid corporis sit id",
            "tempora voluptatem est\nmagnam distinctio autem est dolorem\net ipsa molestiae odit rerum itaque corporis nihil nam\neaque rerum error",
            "consequuntur quia voluptate assumenda et\nautem voluptatem reiciendis ipsum animi est provident\nearum aperiam sapiente ad vitae iste\naccusantium aperiam eius qui dolore voluptatem et",
            "quia incidunt ut\naliquid est ut rerum deleniti iure est\nipsum quia ea sint et\nvoluptatem quaerat eaque repudiandae eveniet aut",
            "nihil ea itaque libero illo\nofficiis quo quo dicta inventore consequatur voluptas voluptatem\ncorporis sed necessitatibus velit tempore\nrerum velit et temporibus",
            "fugit harum quae vero\nlibero unde tempore\nsoluta eaque culpa sequi quibusdam nulla id\net et necessitatibus",
            "omnis temporibus quasi ab omnis\nfacilis et omnis illum quae quasi aut\nminus iure ex rem ut reprehenderit\nin non fugit",
            "dolor mollitia quidem facere et\nvel est ut\nut repudiandae est quidem dolorem sed atque\nrem quia aut adipisci sunt",
            "aut vero est\ndolor non aut excepturi dignissimos illo nisi aut quas\naut magni quia nostrum provident magnam quas modi maxime\nvoluptatem et molestiae",
            "qui rem amet aut\ncumque maiores earum ut quia sit nam esse qui\niusto aspernatur quis voluptas\ndolorem distinctio ex temporibus rem",
            "unde voluptatem qui dicta\nvel ad aut eos error consequatur voluptatem\nadipisci doloribus qui est sit aut\nvelit aut et ea ratione eveniet iure fuga",
            "atque consequatur dolorem sunt\nadipisci autem et\nvoluptatibus et quae necessitatibus rerum eaque aperiam nostrum nemo\neligendi sed et beatae et inventore",
            "quod minus alias quos\nperferendis labore molestias quae ut ut corporis deserunt vitae\net quaerat ut et ullam unde asperiores\ncum voluptatem cumque",
            "facere repudiandae vitae ea aut sed quo ut et\nfacere nihil ut voluptates in\nsaepe cupiditate accusantium numquam dolores\ninventore sint mollitia provident",
            "aut culpa quaerat veritatis eos debitis\naut repellat eius explicabo et\nofficiis quo sint at magni ratione et iure\nincidunt quo sequi quia dolorum beatae qui",
            "voluptatem ut possimus laborum quae ut commodi delectus\nin et consequatur\nin voluptas beatae molestiae\nest rerum laborum et et velit sint ipsum dolorem",
            "qui sunt commodi\nsint vel optio vitae quis qui non distinctio\nid quasi modi dicta\neos nihil sit inventore est numquam officiis",
            "ipsum odio harum voluptatem sunt cumque et dolores\nnihil laboriosam neque commodi qui est\nquos numquam voluptatum\ncorporis quo in vitae similique cumque tempore",
            "exercitationem et id quae cum omnis\nvoluptatibus accusantium et quidem\nut ipsam sint\ndoloremque illo ex atque necessitatibus sed",
            "occaecati laudantium ratione non cumque\nearum quod non enim soluta nisi velit similique voluptatibus\nesse laudantium consequatur voluptatem rem eaque voluptatem aut ut\net sit quam",
            "illum et alias quidem magni voluptatum\nab soluta ea qui saepe corrupti hic et\ncum repellat esse\nest sint vel veritatis officia consequuntur cum",
            "id est iure occaecati quam similique enim\nab repudiandae non\nillum expedita quam excepturi soluta qui placeat\nperspiciatis optio maiores non doloremque aut iusto sapiente",
            "eum accusamus aut delectus\narchitecto blanditiis quia sunt\nrerum harum sit quos quia aspernatur vel corrupti inventore\nanimi dicta vel corporis",
            "perferendis omnis esse\nvoluptate sit mollitia sed perferendis\nnemo nostrum qui\nvel quis nisi doloribus animi odio id quas",
            "et enim voluptatem totam laudantium\nimpedit nam labore repellendus enim earum aut\nconsectetur mollitia fugit qui repellat expedita sunt\naut fugiat vel illo quos aspernatur ducimus",
            "a at tempore\nmolestiae odit qui dolores molestias dolorem et\nlaboriosam repudiandae placeat quisquam\nautem aperiam consectetur maiores laboriosam nostrum",
            "et ipsa rem ullam cum pariatur similique quia\ncum ipsam est sed aut inventore\nprovident sequi commodi enim inventore assumenda aut aut\ntempora possimus soluta quia consequatur modi illo",
            "perferendis eaque labore laudantium ut molestiae soluta et\nvero odio non corrupti error pariatur consectetur et\nenim nam quia voluptatum non\nmollitia culpa facere voluptas suscipit veniam",
            "cum esse odio nihil reiciendis illum quaerat\nest facere quia\noccaecati sit totam fugiat in beatae\nut occaecati unde vitae nihil quidem consequatur",
            "dolorem facere itaque fuga odit autem\nperferendis quisquam quis corrupti eius dicta\nrepudiandae error esse itaque aut\ncorrupti sint consequatur aliquid",
            "veritatis qui nihil\nquia reprehenderit non ullam ea iusto\nconsectetur nam voluptas ut temporibus tempore provident error\neos et nisi et voluptate",
            "cumque molestiae officia aut fugiat nemo autem\nvero alias atque sed qui ratione quia\nrepellat vel earum\nea laudantium mollitia",
            "error eum quia voluptates alias repudiandae\naccusantium veritatis maiores assumenda\nquod impedit animi tempore veritatis\nanimi et et officiis labore impedit blanditiis repudiandae",
            "deserunt cumque laudantium\net et odit quia sint quia quidem\nquibusdam debitis fuga in tempora deleniti\nimpedit consequatur veniam reiciendis autem porro minima",
            "tempore dolorum corrupti facilis\npraesentium sunt iste recusandae\nunde quisquam similique\nalias consequuntur voluptates velit",
            "aut eligendi et molestiae voluptatum tempora\nofficia nihil sit voluptatem aut deleniti\nquaerat consequatur eaque\nsapiente tempore commodi tenetur rerum qui quo",
            "sed illum quis\nut aut culpa labore aspernatur illo\ndolorem quia vitae ut aut quo repellendus est omnis\nesse at est debitis",
            "qui debitis vitae ratione\ntempora impedit aperiam porro molestiae placeat vero laboriosam recusandae\npraesentium consequatur facere et itaque quidem eveniet\nmagnam natus distinctio sapiente",
            "necessitatibus libero occaecati\nvero inventore iste assumenda veritatis\nasperiores non sit et quia omnis facere nemo explicabo\nodit quo nobis porro",
            "nulla quo itaque beatae ad\nofficiis animi aut exercitationem voluptatum dolorem doloremque ducimus in\nrecusandae officia consequuntur quas\naspernatur dolores est esse dolores sit illo laboriosam quaerat",
            "sed magni accusantium numquam quidem omnis et voluptatem beatae\nquos fugit libero\nvel ipsa et nihil recusandae ea\niste nemo qui optio sit enim ut nostrum odit",
            "omnis dolor autem qui est natus\nautem animi nemo voluptatum aut natus accusantium iure\ninventore sunt ea tenetur commodi suscipit facere architecto consequatur\ndolorem nihil veritatis consequuntur corporis",
            "omnis aliquam praesentium ad voluptatem harum aperiam dolor autem\nhic asperiores quisquam ipsa necessitatibus suscipit\npraesentium rem deserunt et\nfacere repellendus aut sed fugit qui est",
            "mollitia magnam et\nipsum consequatur est expedita\naut rem ut ex doloremque est vitae est\ncumque velit recusandae numquam libero dolor fuga fugit a",
            "quisquam voluptas ut\npariatur eos amet non\nreprehenderit voluptates numquam\nin est voluptatem dicta ipsa qui esse enim",
            "nam qui possimus deserunt\ninventore dignissimos nihil rerum ut consequatur vel architecto\ntenetur recusandae voluptate\nnumquam dignissimos aliquid ut reprehenderit voluptatibus",
            "non accusamus eum aut et est\naccusantium animi nesciunt distinctio ea quas quisquam\nsit ut voluptatem modi natus sint\nfacilis est qui molestias recusandae nemo",
            "natus numquam enim asperiores doloremque ullam et\nest molestias doloribus cupiditate labore vitae aut voluptatem\nitaque quos quo consectetur nihil illum veniam\nnostrum voluptatum repudiandae ut",
            "sunt qui consequatur similique recusandae repellendus voluptates eos et\nvero nostrum fugit magnam aliquam\nreprehenderit nobis voluptatem eos consectetur possimus\net perferendis qui ea fugiat sit doloremque",
            "eos ullam dolorem impedit labore mollitia\nrerum non dolores\nmolestiae dignissimos qui maxime sed voluptate consequatur\ndoloremque praesentium magnam odio iste quae totam aut",
            "qui adipisci eveniet excepturi iusto magni et\nenim ducimus asperiores blanditiis nemo\ncommodi nihil ex\nenim rerum vel nobis nostrum et non",
            "et inventore sapiente sed\nsunt similique fugiat officia velit doloremque illo eligendi quas\nsed rerum in quidem perferendis facere molestias\ndolore dolor voluptas nam vel quia",
            "dignissimos itaque ab et tempore odio omnis voluptatem\nitaque perferendis rem repellendus tenetur nesciunt velit\nqui cupiditate recusandae\nquis debitis dolores aliquam nam",
            "illum et voluptatem quis repellendus quidem repellat\nreprehenderit voluptas consequatur mollitia\npraesentium nisi quo quod et\noccaecati repellendus illo eius harum explicabo doloribus officia",
            "officiis dolorem voluptas aliquid eveniet tempora qui\nea temporibus labore accusamus sint\nut sunt necessitatibus voluptatum animi cumque\nat reiciendis voluptatem iure aliquid et qui dolores et",
            "et consequatur voluptates magnam fugit sunt repellendus nihil earum\nofficiis aut cupiditate\net distinctio laboriosam\nmolestiae sunt dolor explicabo recusandae",
            "ratione ut magni voluptas\nexplicabo natus quia consequatur nostrum aut\nomnis enim in qui illum\naut atque laboriosam aliquid blanditiis quisquam et laborum",
            "quisquam incidunt dolores sint qui doloribus provident\nvel cupiditate deleniti alias voluptatem placeat ad\nut dolorem illum unde iure quis libero neque\nea et distinctio id",
            "eum culpa debitis sint\neaque quia magni laudantium qui neque voluptas\nvoluptatem qui molestiae vel earum est ratione excepturi\nsit aut explicabo et repudiandae ut perspiciatis",
            "assumenda corporis architecto repudiandae omnis qui et odit\nperferendis velit enim\net quia reiciendis sint\nquia voluptas quam deserunt facilis harum eligendi",
            "laudantium corrupti atque exercitationem quae enim et veniam dicta\nautem perspiciatis sit dolores\nminima consectetur tenetur iste facere\namet est neque",
            "quibusdam rerum quia nostrum culpa\nculpa est natus impedit quo rem voluptate quos\nrerum culpa aut ut consectetur\nsunt esse laudantium voluptatibus cupiditate rerum",
            "vitae cupiditate excepturi eum veniam laudantium aspernatur blanditiis\naspernatur quia ut assumenda et magni enim magnam\nin voluptate tempora\nnon qui voluptatem reprehenderit porro qui voluptatibus",
            "qui nisi at maxime deleniti quo\nex quas tenetur nam\ndeleniti aut asperiores deserunt cum ex eaque alias sit\net veniam ab consequatur molestiae"
        };

        /// <summary>
        /// Extracted from https://jsonplaceholder.typicode.com / https://github.com/typicode/jsonplaceholder
        /// License: MIT
        /// </summary>
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private static IEnumerable<string> CommentContentsFritz => new[]
        {
            "nihil necessitatibus omnis asperiores nobis praesentium quia\nab debitis quo deleniti aut sequi commodi\nut perspiciatis quod est magnam aliquam modi\neum quos aliquid ea est",
            "ut quis et id repellat labore\nnobis itaque quae saepe est ullam aut\ndolor id ut quis\nsunt iure voluptates expedita voluptas doloribus modi saepe autem",
            "reiciendis delectus nulla quae voluptas nihil provident quia\nab corporis nesciunt blanditiis quibusdam et unde et\nmagni eligendi aperiam corrupti perspiciatis quasi\nneque iure voluptatibus mollitia",
            "at ut tenetur rem\nut fuga quis ea magnam alias\naut tempore fugiat laboriosam porro quia iure qui\narchitecto est enim",
            "eum itaque quam\nlaboriosam sequi ullam quos nobis\nomnis dignissimos nam dolores\nfacere id suscipit aliquid culpa rerum quis",
            "est ducimus voluptate saepe iusto repudiandae recusandae et\nsint fugit voluptas eum itaque\nodit ab eos voluptas molestiae necessitatibus earum possimus voluptatem\nquibusdam aut illo beatae qui delectus aut officia veritatis",
            "ex et expedita cum voluptatem\nvoluptatem ab expedita quis nihil\nesse quo nihil perferendis dolores velit ut culpa aut\ndolor maxime necessitatibus voluptatem",
            "aut quam consequatur sit et\nrepellat maiores laborum similique voluptatem necessitatibus nihil\net debitis nemo occaecati cupiditate\nmodi dolorum quia aut",
            "architecto dolorem ab explicabo et provident et\net eos illo omnis mollitia ex aliquam\natque ut ipsum nulla nihil\nquis voluptas aut debitis facilis",
            "ut aut maxime officia sed aliquam et magni autem\nveniam repudiandae nostrum odio enim eum optio aut\nomnis illo quasi quibusdam inventore explicabo\nreprehenderit dolor saepe possimus molestiae",
            "aut dolorem quos ut non\naliquam unde iure minima quod ullam qui\nfugiat molestiae tempora voluptate vel labore\nsaepe animi et vitae numquam ipsa",
            "totam eum fugiat repellendus\nquae beatae explicabo excepturi iusto et\nrepellat alias iure voluptates consequatur sequi minus\nsed maxime unde",
            "qui aperiam labore animi magnam odit est\nut autem eaque ea magni quas voluptatem\ndoloribus vel voluptatem nostrum ut debitis enim quaerat\nut esse eveniet aut",
            "ut rerum illum error at inventore ab nobis molestiae\nipsa architecto temporibus non aliquam aspernatur omnis quidem aliquid\nconsequatur non et expedita cumque voluptates ipsam quia\nblanditiis libero itaque sed iusto at",
            "dolores debitis voluptatem ab hic\nmagnam alias qui est sunt\net porro velit et repellendus occaecati est\nsequi quia odio deleniti illum",
            "eveniet fugit qui\nporro eaque dolores eos adipisci dolores ut\nfugit perferendis pariatur\nnumquam et repellat occaecati atque ipsum neque",
            "at a vel sequi nostrum\nharum nam nihil\ncumque aut in dolore rerum ipsa hic ratione\nrerum cum ratione provident labore ad quisquam repellendus a",
            "aliquid qui dolorem deserunt aperiam natus corporis eligendi neque\nat et sunt aut qui\nillum repellat qui excepturi laborum facilis aut omnis consequatur\net aut optio ipsa nisi enim",
            "cum sequi in eligendi id eaque\ndolores accusamus dolorem eum est voluptatem quisquam tempore\nin voluptas enim voluptatem asperiores voluptatibus\neius quo quos quasi voluptas earum ut necessitatibus",
            "ullam autem et\naccusantium quod sequi similique soluta explicabo ipsa\neius ratione quisquam sed et excepturi occaecati pariatur\nmolestiae ut reiciendis eum voluptatem sed",
            "ut tempora deleniti quo molestiae eveniet provident earum occaecati\nest nesciunt ut pariatur ipsa voluptas voluptatem aperiam\nqui deleniti quibusdam voluptas molestiae facilis id iusto similique\ntempora aut qui",
            "voluptatem sint quia modi accusantium alias\nrecusandae rerum voluptatem aut sit et ut magnam\nvoluptas rerum odio quo labore voluptatem facere consequuntur\nut sit voluptatum hic distinctio",
            "nihil labore qui\nquis dolor eveniet iste numquam\nporro velit incidunt\nlaboriosam asperiores aliquam facilis in et voluptas eveniet quasi",
            "laudantium tempore aut\nmaiores laborum fugit qui suscipit hic sint officiis corrupti\nofficiis eum optio cumque fuga sed voluptatibus similique\nsit consequuntur rerum commodi",
            "quia voluptas qui assumenda nesciunt harum iusto\nest corrupti aperiam\nut aut unde maxime consequatur eligendi\nveniam modi id sint rem labore saepe minus",
            "doloribus esse necessitatibus qui eos et ut est saepe\nsed rerum tempore est ut\nquisquam et eligendi accusantium\ncommodi non doloribus",
            "repudiandae aliquam maxime cupiditate consequatur id\nquas error repellendus\ntotam officia dolorem beatae natus cum exercitationem\nasperiores dolor ea",
            "et omnis consequatur ut\nin suscipit et voluptatem\nanimi at ut\ndolores quos aut numquam esse praesentium aut placeat nam",
            "iusto sint recusandae placeat atque perferendis sit corporis molestiae\nrem dolor eius id delectus et qui\nsed dolorem reiciendis error ullam corporis delectus\nexplicabo mollitia odit laborum sed itaque deserunt rem dolorem",
            "soluta mollitia impedit cumque nostrum tempore aut placeat repellat\nenim adipisci dolores aut ut ratione laboriosam necessitatibus vel\net blanditiis est iste sapiente qui atque repellendus alias\nearum consequuntur quia quasi quia",
            "doloribus veritatis a et quis corrupti incidunt est\nharum maiores impedit et beatae qui velit et aut\nporro sed dignissimos deserunt deleniti\net eveniet voluptas ipsa pariatur rem ducimus",
            "nostrum perspiciatis doloribus\nexplicabo soluta id libero illo iste et\nab expedita error aliquam eum sint ipsum\nmodi possimus et",
            "ut ut eius qui explicabo quis\niste autem nulla beatae tenetur enim\nassumenda explicabo consequatur harum exercitationem\nvelit itaque consectetur et possimus",
            "aut voluptas dolore autem\nreprehenderit expedita et nihil pariatur ea animi quo ullam\na ea officiis corporis\neius voluptatum cum mollitia dolore quaerat accusamus",
            "est qui ut tempore temporibus pariatur provident qui consequuntur\nlaboriosam porro dignissimos quos debitis id laborum et totam\naut eius sequi dolor maiores amet\nrerum voluptatibus quod ratione quos labore fuga sit",
            "omnis consequatur dignissimos iure rerum odio\nculpa laudantium quia voluptas enim est nisi\ndoloremque consequatur autem officiis necessitatibus beatae et\net itaque animi dolor praesentium",
            "exercitationem eius aut ullam vero\nimpedit similique maiores ea et in culpa possimus omnis\neos labore autem quam repellendus dolores deserunt voluptatem\nnon ullam eos accusamus",
            "fugit minima voluptatem est aut sed explicabo\nharum dolores at qui eaque\nmagni velit ut et\nnam et ut sunt excepturi repellat non commodi",
            "dicta sit culpa molestiae quasi at voluptate eos\ndolorem perferendis accusamus rerum expedita ipsum quis qui\nquos est deserunt\nrerum fuga qui aliquam in consequatur aspernatur",
            "rem magnam at voluptatem\naspernatur et et nostrum rerum\ndignissimos eum quibusdam\noptio quod dolores et",
            "ullam harum consequatur est rerum est\nmagni tenetur aperiam et\nrepudiandae et reprehenderit dolorum enim voluptas impedit\neligendi quis necessitatibus in exercitationem voluptatem qui",
            "sunt quis iure molestias qui ipsa commodi dolore a\nodio qui debitis earum\nunde ut omnis\ndoloremque corrupti at repellendus earum eum",
            "corrupti perspiciatis eligendi\net omnis tempora nobis dolores hic\ndolorum vitae odit\nreiciendis sunt odit qui",
            "sapiente nostrum dolorem odit a\nsed animi non architecto doloremque unde\nnam aut aut ut facilis\net ut autem fugit minima culpa inventore non",
            "cum natus qui dolorem dolorum nihil ut nam tempore\nmodi nesciunt ipsum hic\nrem sunt possimus earum magnam similique aspernatur sed\ntotam sed voluptatem iusto id iste qui",
            "reiciendis maiores id\nvoluptas sapiente deserunt itaque\nut omnis sunt\nnecessitatibus quibusdam dolorem voluptatem harum error",
            "dolorem suscipit adipisci ad cum totam quia fugiat\nvel quia dolores molestiae eos\nomnis officia quidem quaerat alias vel distinctio\nvero provident et corporis a quia ut",
            "facilis cumque nostrum dignissimos\ndoloremque saepe quia adipisci sunt\ndicta dolorum quo esse\nculpa iste ut asperiores cum aperiam",
            "velit ipsa fugiat sit qui vel nesciunt sapiente\nrepudiandae perferendis nemo eos quos perspiciatis aperiam\ndoloremque incidunt nostrum temporibus corrupti repudiandae vitae non corporis\ncupiditate suscipit quod sed numquam excepturi enim labore",
            "et ullam id eligendi rem sit\noccaecati et delectus in nemo\naut veritatis deserunt aspernatur dolor enim voluptas quos consequatur\nmolestiae temporibus error",
            "cumque voluptas quo eligendi sit\nnemo ut ut dolor et cupiditate aut\net voluptatem quia aut maiores quas accusantium expedita quia\nbeatae aut ad quis soluta id dolorum",
            "est quasi maiores nisi reiciendis enim\ndolores minus facilis laudantium dignissimos\nreiciendis et facere occaecati dolores et\npossimus et vel et aut ipsa ad",
            "voluptatem unde consequatur natus nostrum vel ut\nconsequatur sequi doloremque omnis dolorem maxime\neaque sunt excepturi\nfuga qui illum et accusamus",
            "assumenda nihil et\nsed nulla tempora porro iste possimus aut sit officia\ncumque totam quis tenetur qui sequi\ndelectus aut sunt"
        };
    }
}
