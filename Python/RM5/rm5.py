import mysql.connector

def connect_to_db():
    return mysql.connector.connect(
        host="localhost", 
        user="root",       
        password="",     
        database="klienti"  
    )

def create_record(cursor, emri, mosha):
    sql = "INSERT INTO klienit (emri, mosha) VALUES (%s, %s)"
    values = (emri, mosha)
    cursor.execute(sql, values)

def read_records(cursor):
    cursor.execute("SELECT * FROM klienti")
    for row in cursor.fetchall():
        print(row)

def update_record(cursor, student_id, emri_ri, mosha_re):
    sql = "UPDATE klienti SET emri = %s, mosha = %s WHERE id = %s"
    values = (emri_ri, mosha_re, student_id)
    cursor.execute(sql, values)

def delete_record(cursor, student_id):
    sql = "DELETE FROM klienti WHERE id = %s"
    cursor.execute(sql, (student_id,))

def main():
    db = connect_to_db()
    cursor = db.cursor()
    

    create_record(cursor, "Arben", 21)
    db.commit()
    
    read_records(cursor)
    
    update_record(cursor, 1, "Arben H", 22)
    db.commit()
    
    delete_record(cursor, 1)
    db.commit()
    
    cursor.close()
    db.close()

if __name__ == "__main__":
    main()