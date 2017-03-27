const int lightBtnPin1 = 2;     // The number of the pushbutton pin
const int beepsBtnPin2 = 4;     // The number of the pushbutton pin
const int speedBtnPin3 = 7;     // The number of the pushbutton pin

const int MAXGAS     = 50;   // Max speed car

int    gasAmount      =  0;      // Pushed gas amount
bool   toggleLight    =  false;
String controllerState= "";  // Variable for reading the pushbutton status

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  // Set buttons as input
  pinMode(lightBtnPin1, INPUT_PULLUP);
  pinMode(beepsBtnPin2, INPUT);
  pinMode(speedBtnPin3, INPUT);
}

void loop() {
  // Reading gas button
  int GasBtn =  digitalRead(speedBtnPin3);
  
  // Add speed based on the amount of time you push gas button
  if(GasBtn && gasAmount<MAXGAS){
     gasAmount++;
  }
  else if(!GasBtn && gasAmount>0){
     gasAmount--;
  }
  
  // Prepareing string with ccancatenating data with comma
  controllerState  = (String)digitalRead(lightBtnPin1) + ",";
  controllerState += (String)digitalRead(beepsBtnPin2) + ",";
  
  // Set range sound 0-100
  float soundOut = (float)analogRead(A0)/1000;
  
  if(soundOut>1){
    soundOut = 1;
  }
    
  controllerState += (String)soundOut + ",";
  controllerState += (String)gasAmount;

  Serial.println(controllerState);
  delay(50);
}
