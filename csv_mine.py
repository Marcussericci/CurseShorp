import csv
def read_all_employees(filename):
    with open(filename, 'r', encoding='utf-8') as f:
        csv_reader = csv.reader(f)
        for row in csv_reader:
            print(row)



def read_all_employees_to_dict(filename):
    with open(filename, 'r', encoding='utf-8') as f:
        csv_dict_reader = csv.DictReader(f)
        for employee in csv_dict_reader:
            print(f"{employee['name']} works in {employee['department']} department")



def filter_it_employees(filename):
    it_employees = []
    with open(filename, 'r', encoding='utf-8') as f:
        csv_dict_reader = csv.DictReader(f)
        for employee in csv_dict_reader:
            if employee['department'] == 'IT':
                it_employees.append(employee)
    return it_employees



def write_employees(filename, employees, field_names):
    with open(filename, 'w', encoding='utf-8', newline='') as f:
        writer = csv.DictWriter(f, fieldnames=field_names)
        writer.writeheader()
        writer.writerows(employees)



def calculate_average_salary(filename):
    total_salary = 0
    count = 0
    with open(filename, 'r', encoding='utf-8') as f:
        csv_dict_reader = csv.DictReader(f)
        for employee in csv_dict_reader:
            salary = float(employee['salary'])
            total_salary += salary
            count += 1
    return total_salary / count if count > 0 else 0



def get_employees_by_salary(filename, min_salary):
    employees = []
    with open(filename, 'r', encoding='utf-8') as f:
        csv_dict_reader = csv.DictReader(f)
        for employee in csv_dict_reader:
            if float(employee['salary']) > min_salary:
                employees.append(employee)
    return employees



def calculate_average_salary_by_department(input_filename, output_filename):
    dept_salaries = {}

    
    with open(input_filename, 'r', encoding='utf-8') as f:
        csv_dict_reader = csv.DictReader(f)
        for employee in csv_dict_reader:
            dept = employee['department']
            salary = float(employee['salary'])

            if dept not in dept_salaries:
                dept_salaries[dept] = {'total': 0, 'count': 0}
            dept_salaries[dept]['total'] += salary
            dept_salaries[dept]['count'] += 1

    
    results = []
    for dept, data in dept_salaries.items():
        avg_salary = data['total'] / data['count']
        results.append({'department': dept, 'average_salary': round(avg_salary, 2)})

    
    with open(output_filename, 'w', encoding='utf-8', newline='') as f:
        fieldnames = ['department', 'average_salary']
        writer = csv.DictWriter(f, fieldnames=fieldnames)
        writer.writeheader()
        writer.writerows(results)



if __name__ == "__main__":
    employees_file = 'employees.csv'

    
    avg_salary = calculate_average_salary(employees_file)
    print(f"\nСредняя зарплата всех сотрудников: {avg_salary:.2f}")

    
    try:
        min_salary = float(input("\nВведите минимальную зарплату для фильтрации: "))
        high_paid = get_employees_by_salary(employees_file, min_salary)

        if high_paid:
            print(f"\nСотрудники с зарплатой выше {min_salary}:")
            for emp in high_paid:
                print(f"{emp['name']} — {emp['salary']} ({emp['department']})")
        else:
            print(f"\nНет сотрудников с зарплатой выше {min_salary}")
    except ValueError:
        print("Ошибка: нужно ввести число.")

    
    calculate_average_salary_by_department(employees_file, 'departments_avg_salary.csv')
    print("\nФайл 'departments_avg_salary.csv' успешно создан!")
