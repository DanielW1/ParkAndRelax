import re
from urllib.request import urlopen as uReq
from bs4 import BeautifulSoup as soup
import pyodbc



listdates = []
listnames = []
listcategories = []
listprices = []
listinfos = []
listplaces = []

my_url = ['http://kulturalnie.waw.pl/','https://goingapp.pl/calendar/1/warszawa/1/any/any']

uClient = uReq(my_url[0])
page_html = uClient.read()
uClient.close()

page_soup = soup(page_html, "html.parser")

events = page_soup.findAll("li", {"class":"event"})

for container in events:
    originaldate_ISO = container.find_all("span", {"class": "date"})[0].text
    originaldate_UTF = originaldate_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
    print("DATA: " + originaldate_UTF)
    listdates.append(originaldate_UTF)

    originalname_ISO = (container.find_all("h2", {"itemprop": "name"})[0].text).strip()
    [line for line in originalname_ISO.split("\n") if line.strip() != '']
    originalname_UTF = originalname_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
    print("NAZWA: " + originalname_UTF)
    listnames.append(originalname_UTF)

    #strip eliminuje spacje przed i po stringu

    originalcategory_ISO = (container.find_all("li", {"class": "category"})[0].text).strip()
    originalcategory_UTF = originalcategory_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
    print("Kategoria: " +originalcategory_UTF)
    if "|" in originalcategory_UTF:
        new_original_category_UTF = originalcategory_UTF.replace("|", "")
        listcategories.append(new_original_category_UTF)
    else:
        listcategories.append(originalcategory_UTF)

    originalplace_ISO = (container.find_all("li", {"class": "location"})[0].text).strip()
    originalplace_UTF = originalplace_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
    listplaces.append(originalplace_UTF)
    print("Miejsce: " + originalplace_UTF)

    originalprice_ISO =  (container.find_all("li", {"class": "tickets"})[0].text).strip()
    originalprice_UTF = originalprice_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
    print(originalprice_UTF)
    listprices.append(originalprice_UTF)

    originalinfo_ISO = (container.find_all("div", {"class": "eventDescription"})[0].text).strip()
    originalinfo_UTF = originalinfo_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
    if "\'" in originalinfo_UTF:
        new_originalinfo_UTF = originalinfo_UTF.replace("\'"," ")
        listinfos.append(new_originalinfo_UTF)
        print("Informacje: " + new_originalinfo_UTF)
    else:
        listinfos.append(originalinfo_UTF)
        print("Informacje: " + originalinfo_UTF)



    print("\n")







#webscraping drugiego urla


uClient = uReq(my_url[1])
page_html = uClient.read()
uClient.close()

# html parsing
page_soup = soup(page_html, "html.parser")

# bierze kazdy event
events2 = page_soup.findAll("div", {"class": "event_list_item_inner"})


for container2 in events2:
    #print("DATA: " + container2.find_all("a", {"target": "_parent"})[0].text)
    originalname_2 = (container2.find_all("p", {"class": "event_info_box_title"})[0].text).strip()
    [line for line in originalname_2.split("\n") if line.strip() != '']
    print("NAZWA: " + originalname_2)
    listnames.append(originalname_2)

    # strip eliminuje spacje przed i po stringu
    originalcategory_2 = (container2.find_all("a", {"class": "event_category_label_link"})[0].text).strip()
    print("Kategoria: " + originalcategory_2)
    if "|" in originalcategory_2:
        new_original_category_2 = info2.replace("|", "")
        listcategories.append(new_original_category_2)
    else:
        listcategories.append(originalcategory_2)

    originaltime_2 = (container2.find_all("p", {"class": "event_info_box_info"})[0].text).strip()
    print("Godzina: " + originaltime_2)
    listdates.append(originaltime_2)

    #print("Miejsce: " + (container2.find_all("a", {"id": "event_infobox_place_link"})[1].text).strip())
    originalprice_2 = (container2.find_all("p", {"class": "event_info_box_type_mobile_price"})[0].text).strip()
    listprices.append(originalprice_2)
    print("CENA:" + originalprice_2)

    #print("Informacje: " + (container2.find_all("div", {"class": "event_desc"})[0].text).strip())
    #info = (container2.find_all("div", {"class": "event_desc"})[0].text).strip()
    info_2 = container2.find('div', attrs={'class':'event_desc'}).text
    info2 = " ".join(re.split("\s+", info_2, flags=re.UNICODE))
    info3 = info2 + "\n"
    if "\'" in info2:
        new_info2 = info2.replace("\'", " ")
        listinfos.append(new_info2)
    else:
        listinfos.append(info2)
    print("Informacje: " + info3)

    print("")


#zapis w pętli do bazy danych

i=1;

cnxn = pyodbc.connect('Driver={SQL Server};Server=LAPTOP-3HJ4DJM0\SQLEXPRESS;Database=Test-Inzynierka;Trusted_Connection=yes;')
cursor = cnxn.cursor()
cursor.execute("DELETE FROM [EVENTS_NOW]")
cnxn.commit()
for name, date, price, category, info in zip(listnames, listdates, listprices, listcategories, listinfos):
    cursor.execute("INSERT INTO [EVENTS_NOW] VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');".format(i, name, date, price, category, info))
    cnxn.commit()
    i = i+1