TypeIT-Wearable (glove) keyboard.
Hardware: Two glove keyboard with 5 switches each, arduino nano, and bluetooth module
The master glove returns input data like S0000000000E, S1000000000E (s-start, e-end)
Software: WinForms app that helps customize profiles and key mappings.

Profiles: has various sets of key mappings
Key mappings: maps each switch to a key, macro, or combination of keys

---------------------------------

ARDUINO 
    - in charge of the wireless communication of Left glove(master) and Right glove(slave)
    - reads the switches states and sends the data to the connected device (PC)
    - every key press or release is sent
    - data looks like this: S0000000000E, S1000000000E (s-start, e-end)
    - S1000000000E - left pinky pressed (every key press, an update is made) 
    - S0000000000E - left pinky released (every key release, an update is made)
