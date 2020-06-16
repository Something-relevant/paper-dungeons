import random

quality = 2 #resolution of poster

numTiles = 41  #number of images

tileSize = 248/quality 
images = []
rotation = [radians(0),  radians(90), radians(180), radians(270)]

rowLength = 42 #12.4 (( size/rowLength + 6) for 3 gap) (*3 = 37.2)
colLength = 62

posX = 744/quality
posY = 744/quality

r1 = random.randint(0, 40)
r2 = random.randint(0, 3)

def setup():
    size(11900/quality, 16840/quality)
    background('#ffffff')
    
    makePoster()
    
    save("paper_dungeons_posterHQ.tiff")
    save("paper_dungeons_posterHQ.png")
    
    
    

def makePoster():
    
 #Tile Generator
 
    global posX, posY, r1, r2, numTiles, tileSize
    
    for i in range(numTiles):
        imageName = str("Tile (" + str(i + 1) + ").png")
        images.append(loadImage(imageName))
        
    for i in range(colLength):
            
        for i in range(rowLength):
            pushMatrix();
            rotateX(rotation[r2])
            image(images[r1], posX, posY, tileSize, tileSize)
            popMatrix();
            posX += tileSize
            r1 = random.randint(0, 40)
            r2 = random.randint(0, 3)
            
        
        posX = 744/quality
        posY += tileSize
         
    
 #QR Code
 
    qrSize = tileSize * 6
    qr = loadImage("paper_dungeons_QR_Code.png")
    
    fill(255)
    strokeWeight(0)
    
    image(qr,
          tileSize * rowLength - qrSize/2,
          tileSize * colLength - 3 * tileSize, 
          qrSize,
          qrSize)
    
 #LogoType
 
    logoSize = tileSize * 5.75
    logo = loadImage("LogoType2.png")
    
    image(logo, 
          tileSize * rowLength - logoSize/2,
          tileSize * colLength + 3 * tileSize, 
          logoSize,
          tileSize * 0.9)    
    
