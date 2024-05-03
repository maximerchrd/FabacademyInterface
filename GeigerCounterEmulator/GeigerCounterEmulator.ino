void setup() {
  Serial.begin(9600);
}

void loop() {
  int randomNumber = random(10000);
  if (randomNumber < 3000 && randomNumber % 7 == 0) {
    Serial.print("0");
  } else if (randomNumber > 7000 && randomNumber % 3 == 0) {
    Serial.print("1");
  }
  delay(500);
}
