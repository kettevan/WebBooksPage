# WebBooksPage

### ეს არის წიგნების გაყიდვის საიტის ახალი git repository, წინა კომიტები შენახულია ძველ რეპოზიტორზე, რომლის მისამართია https://github.com/kettevan/WebBooks/tree/master, მუშაობის პროცესში ვეღარ შევძელი ძველ რეპოზიტორზე დამატება და მომიწია ახლის შექმნა

### დაჰოსტვის გამო მომიწია ჩემი დაწერილი api-ის "გაუქმება", რადგან მქონდა .net core-ზე დაწერილი და დაჰოსტვის შემდეგ ყველა url იყო http ტიპის ხოლო Front-ის url https ტიპის, რის გამოც წარმოიქმნა mixed platform-ის პრობლემა და მომიწია მთელი მონაცემების json-ად გადაკეთება, თუმცა api-ის პროექტი არის რეპოზიტორში და ლოკალურად გაშვების შემთხვევაში მუშაობს. 
 
#### დაჰოსტილი აპი-ის მისამართებია: http://ketevandt-001-site1.etempurl.com/books -რომელიც ყველა წიგნს ტვირთავს, http://ketevandt-001-site1.etempurl.com/getUserBooks?userId= რომელიც იუზერიც დამატებულ წიგნებს აბრუნებს, http://ketevandt-001-site1.etempurl.com/getUser?email=bob@mail.com&password=123 რომელიც იუზერზე გვიბრუნებს ინფორმაციას, http://ketevandt-001-site1.etempurl.com/addCartItem?userid=20660f28-8293-4dc2-a27a-fecb4eb42349&id=392f0cd0-6913-4d1c-a92b-f889684ff7aa რომლითაც ვამატებთ კალათში წიგნს და ასევე იუზერის რეგისტრაციის ლინკიც არის. (თითოეული პარამეტრი შესაცვლელია შესაბამისი მნიშვნელობებით)

#### დალოგინებისთვის შეგიძლიათ გამოიყენოთ email: bob@mail.com ხოლო პაროლად 123

## ამჟამად გვერდზე შესაძლებელია დალოგინება, რეგისტრაცია, წიგნების გაფილტვრა ავტორით ან სახელით, წიგნების დეტალების ნახვა, კალათში დამატება და კალათში არსებული წიგნების ნახვა

# ვებ გვერდის მისამართია https://bookweb-6eb50.web.app/
