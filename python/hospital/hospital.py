#Patient Class

class Patient(object):
    def __init__(self,hId,name,allergies):
        self.hId = hId
        self.name = name
        self.allergies = allergies
        self.bedNumber = None

#Hospital Class

class Hospital(object):
    def __init__(self):
        self.patients = []
        self.hName = "St. Coolguy's Hospital"
        self.capacity = 4
        self.patientCount = 0

    def admit(self, newPatient):
        if len(self.patients) < self.capacity:
            self.patients.append(newPatient)
            self.patientCount += 1
            newPatient.bed = len(self.patients) #This is not ideal, as once a patient is discharged, it does not reassign their bed number.         
            print "New patient added to bed. Total patients:", self.patientCount
            print " "
        else:
            print "Hospital is full! Cannot accept new patient."
            print " "
        return self

    def discharge(self, newPatient):
        newPatient.bedNumber = None
        newPatient.bed = None
        self.patients.remove(newPatient)
        self.patientCount -= 1
        print newPatient.name, "has been discharged."
        print " "
        return self

    def display (self):
        print "List of patients:"
        for i in self.patients:
            print "ID:", i.hId, "| Name:", i.name, "| Allergies:", i.allergies, "| Bed Number:", i.bed
            print " "
        return self

patient1 = Patient(123,"Nat","No Allergies")
patient2 = Patient(124,"Will","Fun")
patient3 = Patient(125,"Balazs","Meat")
patient4 = Patient(126,"Josh","Pineapple")
patient5 = Patient(127, "Madison","Being Alive")

newPatient = Hospital()
newPatient.admit(patient1)
newPatient.admit(patient2)
newPatient.admit(patient3)
newPatient.admit(patient4)
newPatient.admit(patient5)
newPatient.display()
newPatient.discharge(patient3)
newPatient.display()
