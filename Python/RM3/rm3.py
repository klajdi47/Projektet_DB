import sys
from functools import reduce

def factorial(n):
    result = 1
    for i in range(2, n + 1):
        result *= i
    return result

def fibonacci(n):
    fib = [0, 1]
    for _ in range(n - 2):
        fib.append(fib[-1] + fib[-2])
    return fib[:n]

def sum_list(numbers):
    return reduce(lambda x, y: x + y, numbers, 0)

def average_list(numbers):
    return sum_list(numbers) / len(numbers) if numbers else 0

def sort_numbers(numbers):
    return sorted(numbers)

def main_menu():
    actions = {
        '1': lambda: print(f"Faktorial: {factorial(int(input('Numri: ')))}"),
        '2': lambda: print(f"Fibonacci: {fibonacci(int(input('Numri: ')))}"),
        '3': lambda: print(f"Shuma: {sum_list(list(map(int, input('Numrat: ').split())))}"),
        '4': lambda: print(f"Mesatarja: {average_list(list(map(int, input('Numrat: ').split())))}"),
        '5': lambda: print(f"Renditur: {sort_numbers(list(map(int, input('Numrat: ').split())))}"),
        '6': lambda: sys.exit("Duke dalë...")
    }
    while True:
        choice = input("\n1.Faktorial 2.Fibonacci 3.Shuma 4.Mesatarja 5.Renditja 6.Dil: ")
        actions.get(choice, lambda: print("Zgjedhje e pavlefshme"))()

if __name__ == "__main__":
    main_menu()