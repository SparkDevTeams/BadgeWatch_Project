# -*- coding: utf-8 -*-

# Sample Python code for youtube.videos.list
# See instructions for running these code samples locally:
# https://developers.google.com/explorer-help/guides/code_samples#python

import os
import json

import google_auth_oauthlib.flow
import googleapiclient.discovery
import googleapiclient.errors



scopes = ["https://www.googleapis.com/auth/youtube.readonly"]

channelIDs = []

# VIDEO TAGS BY NEWS STATION
local10VideoIDs = [
    'eSfDV-pOQAs','G-Q_YPdYc6w','OolLYEYJdLk','uHYUmv5wcPc',
    'xSUXP3nH9gQ','TkSbildnHRE','qQ1x-gUNJLQ','kTbst61jhRc',
    'PTmdvFZUIv4','bs-6HoOeJL4','17YejAc_xEI','oHB09yVJet8']
localWSVN = []
localWPG = []
miamiHerald = [
    'YuSEoMeaCIY','wwgKS_UyX4w','VqjZ7x5lBq0','sKFxbqH6iko',
    'oQ8fLp1o16g','mRSnVobrmzM','aBTsKj99naQ','Su8n-DyEh6U']

nbc6 = ['48gNUvPNs5o','4_t2fP4XtHl']

cbs = [
    'IjQ4icYwITo','LAK57l90ovQ','pU5DpAmdGq8','DxhbNq5GjgM',
    'JlsjqC657Gk','Y8B8KZBTzJc','h-AQp2hNpyQ','cBs-QKsoD3s',
    'b63nerMQmcI','kV5LOlALwok','1TVmJ5CmmI8','ar_7QASFqXI',
    '0UguBEr6WDI','UKQyf6qnY5E','WAKUW9l-MaA','RCVsuViKDJQ',
    'zvArW3elB7g','vX-r9hIZzcQ','ReYSiBK6_eo']

newsStations = [local10VideoIDs,localWSVN,localWPG,miamiHerald,nbc6,cbs]

allTags = []


def main():
    # Disable OAuthlib's HTTPS verification when running locally.
    # *DO NOT* leave this option enabled in production.
    os.environ["OAUTHLIB_INSECURE_TRANSPORT"] = "1"

    api_service_name = "youtube"
    api_version = "v3"
    client_secrets_file = "../APICredentials.json"

    # Get credentials and create an API client
    flow = google_auth_oauthlib.flow.InstalledAppFlow.from_client_secrets_file(
        client_secrets_file, scopes)
    
    #yah = input("Continue 1?")
    #test = flow
    #print(flow)
    credentials = flow.run_console()

    print("\n\nCredentials: {}\n\n".format(credentials))
    yah = input("Continue 2?")
    youtube = googleapiclient.discovery.build(
        api_service_name, api_version, credentials=credentials)


    for station in newsStations:

        # FOR EVERY RELEVANT VIDEO IN A STATIONS CHANNEL, PERFORM FOLLOWING ACTION
        for vidID in station:

            # SUBMITS THE API REQUEST FOR THE DESIRED 'PARTS' FOR THE SPECIFIC VIDEO ID
            request = youtube.videos().list(
                part="snippet,contentDetails,statistics",
                id=vidID
            )
            response = request.execute()

            # CREATES A JSON FILE THE VIDEO WITH THEIR SPECIC API RESPONSE DATA
            """with open('data_{}.json'.format(vidID),'w+') as f:
                json.dump(response,f)"""

            # WORKS ON THE VIDEO'S TAGS AND CATEGORY, IF THERE ARE TAGS
            try:
                tags = response['items'][0]['snippet']['tags']
                category = response['items'][0]['snippet']['categoryId']
                
                # ADDING THE INDIVIDUAL VIDEO TAGS TO A MASTER TAG LIST
                for i in tags:
                    if i not in allTags:
                        allTags.append(i)

                print("{}, {}: {}\n".format(vidID,category,tags))
            except KeyError as e:
                print("{}\n: No tags".format(vidID))
            except IndexError as e:
                print("No vid info")
        

    print(allTags)



if __name__ == "__main__":
    main()