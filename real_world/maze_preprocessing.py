import cv2  
import numpy as np
import imutils
#import matplotlib.pyplot as plt

class ImagePreprocess:
    '''
    Class for preprocessing images
    Args:
        img_size : wanted size of image. Default to (480, 480)
        threshold_plane : threshold for plane. 
        threshold_ball : threshold color for ball
    '''
    def __init__(self, img_size=(480,480), threshold_plane=192, threshold_ball=100):
        self.img_size = img_size

        # Thresholds
        self.threshold_plane = threshold_plane
        self.threshold_ball = threshold_ball
        self.label_plane = 255 # label of floor
        self.label_ball = 128
        self.label_wall = 0 

        self.last_ball_center = None


    def get_ball_center(self, img):
        lower_Red_hsv1 = np.array([0, 100, 20])
        upper_Red_hsv1 = np.array([15, 255, 255])
        lower_Red_hsv2 = np.array([160, 100, 20])
        upper_Red_hsv2 = np.array([179, 255, 255])
                  
        blurred = cv2.GaussianBlur(img, (11, 11), 0)
        hsv_frame = cv2.cvtColor(blurred, cv2.COLOR_BGR2HSV)
        mask_Red1 = cv2.inRange(hsv_frame, lower_Red_hsv1, upper_Red_hsv1)
        mask_Red2 = cv2.inRange(hsv_frame, lower_Red_hsv2, upper_Red_hsv2)
        mask_Red = mask_Red1 + mask_Red2

        mask_Red = cv2.erode(mask_Red, None, iterations=7)
        mask_Red = cv2.dilate(mask_Red, None, iterations=7)

        cnts = cv2.findContours(mask_Red.copy(), cv2.RETR_EXTERNAL,cv2.CHAIN_APPROX_SIMPLE)
        cnts = imutils.grab_contours(cnts)
        center = None
        # only proceed if at least one contour was found
        if len(cnts) > 0:
        # find the largest contour in the mask, then use
        # it to compute the minimum enclosing circle and centroid      
            c = max(cnts, key=cv2.contourArea)
            ((x, y), radius) = cv2.minEnclosingCircle(c)
            M = cv2.moments(c)
            center = (int(M["m10"] / M["m00"]), int(M["m01"] / M["m00"]))

        return center
    

    def to_label(self, frame):
        img = cv2.resize(frame[:, 80:560], self.img_size, interpolation=cv2.INTER_LANCZOS4)
        
        IMG = img.copy()
        for j in range(IMG[0, :].size):
            for i in range(IMG[:, 0].size):
                if IMG[i,j] >= self.threshold_plane:
                    IMG[i,j] = self.label_plane
                # elif (IMG[i,j] >= self.threshold_ball) and (IMG[i,j] < self.threshold_plane):
                #     IMG[i,j] = self.label_ball
                elif IMG[i,j] < self.threshold_ball:
                    IMG[i,j] = self.label_wall

        center = self.get_ball_center(img)
        if center is not None:
            self.last_ball_center = center
            IMG[center] = self.label_ball
        else:
            IMG[self.last_ball_center] = self.label_ball

        return IMG
        

if __name__=="__main__":
    preprocessor = ImagePreprocess()
    cam = cv2.VideoCapture(1)

    assert cam.isOpened(), "Webcam is not connected"

    while cam.isOpened():
        status, frame = cam.read()

        if status:
            IMG = ImagePreprocess.to_label(frame)
            cv2.imshow("original image", frame)
            cv2.imshow("preprocessed image", IMG)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

    cam.release()
    cv2.destroyAllWindows()
