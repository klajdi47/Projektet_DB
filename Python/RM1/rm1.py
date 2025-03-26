class Book:
    def __init__(self, title, author, year, copies):
        self.title = title
        self.author = author
        self.year = year
        self.copies = copies

    def __str__(self):
        return f"{self.title} - {self.author} ({self.year}), Kopje: {self.copies}"


class Library:
    def __init__(self):
        self.inventory = []
    
    def register_book(self):
        title = input("Titulli: ")
        author = input("Autori: ")
        year = input("Viti: ")
        copies = int(input("Kopje: "))
        self.inventory.append(Book(title, author, year, copies))
    
    def display_books(self):
        for book in self.inventory:
            if book.copies > 0:
                print(book)
    
    def search_books(self):
        while (query := input("Kërko (ose 'dalje'): ").lower()) != 'dalje':
            found = [b for b in self.inventory if query in b.title.lower() or query in b.author.lower() and b.copies > 0]
            print("\n".join(str(b) for b in found) if found else "Nuk u gjet.")
    
    def menu(self):
        options = {"1": self.register_book, "2": self.display_books, "3": self.search_books}
        while (choice := input("1.Regjistro 2.Shfaq 3.Kërko 4.Dalje: ")) != "4":
            options.get(choice, lambda: print("Zgjedhje e pavlefshme"))()


if __name__ == "__main__":
    Library().menu()