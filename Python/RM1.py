def trego_balancen(balanca):
    print(f"\nBalanca juaj aktuale eshte: {balanca:,.2f}€")

def terhiq_para(balanca):
    try:
        shuma = float(input("Shkruani shumen qe deshironi te terhiqni: "))
        if shuma <= 0:
            print("Gabim! Shuma nuk mund te jete negative ose zero.")
        elif shuma > balanca:
            print("Gabim! Nuk keni mjaftueshem para në llogari.")
        else:
            balanca -= shuma
            print(f"Keni terhequr {shuma:,.2f}€. Balanca e re: {balanca:,.2f}€")
    except ValueError:
        print("Gabim! Ju lutemi fusni vetëm numra.")
    return balanca

def depozito_para(balanca):
    try:
        shuma = float(input("Shkruani shumën qe deshironi te depozitoni: "))
        if shuma <= 0:
            print("Gabim! Shuma duhet të jete me e madhe se 0.")
        else:
            balanca += shuma
            print(f"Keni depozituar {shuma:,.2f}€. Balanca e re: {balanca:,.2f}€")
    except ValueError:
        print("Gabim! Ju lutemi fusni vetëm numra.")
    return balanca

def menuja():
    print("\n--- Menuja ---")
    print("1. Trego Balancen")
    print("2. Terhiq Para")
    print("3. Depozito Para")
    print("4. Dalje")

def menaxho_llogarine():
    balanca = 10_000.0

    while True:
        menuja()
        try:
            op = int(input("Zgjidhni opsionin (1-4): "))
        except ValueError:
            print("Gabim! Ju lutemi fusni nje numer nga 1 deri në 4.")
            continue
        
        match op:
            case 1:
                trego_balancen(balanca)
            case 2:
                balanca = terhiq_para(balanca)
            case 3:
                balanca = depozito_para(balanca)
            case 4:
                print("Faleminderit qe perdoret kete sherbim! Dalja...")
                break
            case _:
                print("Opsion i pavlefshëm! Ju lutemi zgjidhni 1, 2, 3 ose 4.")


menaxho_llogarine()
