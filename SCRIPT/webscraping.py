import re
from urllib.request import urlopen as uReq
from bs4 import BeautifulSoup as soup
import pypyodbc as pyodbc

listdates = []
listnames = []
listcategories = []
listprices = []
listinfos = []
listplaces = []

my_url = ['http://kulturalnie.waw.pl/','http://kulturalnie.waw.pl/2/','http://kulturalnie.waw.pl/3/','http://kulturalnie.waw.pl/4/','https://goingapp.pl/calendar/1/warszawa/1/any/any']

for x in range(0,3):
    uClient = uReq(my_url[x])
    page_html = uClient.read()
    uClient.close()

    page_soup = soup(page_html, "html.parser")

    events = page_soup.findAll("li", {"class":"event"})

    for container in events:
        originaldate_ISO = container.find_all("span", {"class": "date"})[0].text
        originaldate_UTF = originaldate_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
        print("DATA: " + originaldate_UTF)
        listdates.append(originaldate_UTF)

        try:
            originalname_ISO = (container.find_all("h2", {"itemprop": "name"})[0].text).strip()
            [line for line in originalname_ISO.split("\n") if line.strip() != '']
            originalname_UTF = originalname_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
            print("NAZWA: " + originalname_UTF)
            listnames.append(originalname_UTF)
        except UnicodeDecodeError:
            b'\0xc4'.decode('utf-8', "replace")
            listnames.append('Błąd przy dekodowaniu')
        #strip eliminuje spacje przed i po stringu

        originalcategory_ISO = (container.find_all("li", {"class": "category"})[0].text).strip()
        originalcategory_UTF = originalcategory_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
        print("Kategoria: " +originalcategory_UTF)
        try:
            if "|" in originalcategory_UTF:
                new_original_category_UTF = originalcategory_UTF.replace("|", "")
                listcategories.append(new_original_category_UTF)
            elif "\'" in originalcategory_UTF:
                new_original_category_UTF = originalcategory_UTF.replace("\'", "")
                listcategories.append(new_original_category_UTF)
            elif "\"" in originalcategory_UTF:
                new_original_category_UTF = originalcategory_UTF.replace("\"", "")
                listcategories.append(new_original_category_UTF)
            else:
                listcategories.append(originalcategory_UTF)
        except UnicodeEncodeError:
            b'\u201e'.decode('utf-8', "replace")
            listcategories.append("Błąd przy kodowaniu")
        originalplace_ISO = (container.find_all("li", {"class": "location"})[0].text).strip()
        originalplace_UTF = originalplace_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
        if "|" in originalplace_UTF:
            new_originalplace = originalplace_UTF.replace("|","")
            listplaces.append(new_originalplace)
        else:
            listplaces.append(originalplace_UTF)


        originalprice_ISO =  (container.find_all("li", {"class": "tickets"})[0].text).strip()
        originalprice_UTF = originalprice_ISO.encode("iso-8859-2",'ignore').decode('utf-8')
        print(originalprice_UTF)
        if "bilety:"  in originalprice_UTF:
            new_originalprice_UTF = originalprice_UTF.replace("bilety:","")
            listprices.append(new_originalprice_UTF)
            print(new_originalprice_UTF)
        elif "Bilety:" in originalprice_UTF:
            new_originalprice_UTF = originalprice_UTF.replace("Bilety:", "")
            listprices.append(new_originalprice_UTF)
            print(new_originalprice_UTF)
        else:
            listprices.append(originalprice_UTF)
            print(originalprice_UTF)

        try:
            originalinfo_ISO = (container.find_all("div", {"class": "eventDescription"})[0].text).strip()
            originalinfo_UTF = originalinfo_ISO.encode("iso-8859-2",'ignore').decode('utf-8')

            if "\'" in originalinfo_UTF:
                new_originalinfo_UTF = originalinfo_UTF.replace("\'"," ")
                listinfos.append(new_originalinfo_UTF)
                print("Informacje: " + new_originalinfo_UTF)
            elif "\"" in originalinfo_UTF:
                new_originalinfo_UTF = originalinfo_UTF.replace("\"", " ")
                listinfos.append(new_originalinfo_UTF)
                print("Informacje: " + new_originalinfo_UTF)
            else:
                listinfos.append(originalinfo_UTF)
                print("Informacje: " + originalinfo_UTF)
        except UnicodeDecodeError:
            b'\0xf3'.decode('utf-8',"replace")
            listinfos.append('Błąd przy dekodowaniu')
        except UnicodeEncodeError:
            listinfos.append('Błąd przy kodowaniu')

        print("\n")



#webscraping drugiego urla


uClient = uReq(my_url[3])
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
    try:
        originalcategory_2 = (container2.find_all("a", {"class": "event_category_label_link"})[0].text).strip()
        print("Kategoria: " + originalcategory_2)

        if "|" in originalcategory_2:
            new_original_category_2 = originalcategory_2.replace("|", "")
            listcategories.append(new_original_category_2)
        else:
            listcategories.append(originalcategory_2)
    except UnicodeEncodeError:
        b'\u201e'.decode('utf-8', "replace")
        listcategories.append("Błąd przy kodowaniu")

    originaltime_2 = (container2.find_all("p", {"class": "event_info_box_info"})[0].text).strip()
    print("Godzina: " + originaltime_2)
    placesanddates = originaltime_2.splitlines()
    listplaces.append(placesanddates[1])
    listdates.append(placesanddates[0])


    originalprice_2 = (container2.find_all("p", {"class": "event_info_box_type_mobile_price"})[0].text).strip()

    print("CENA:" + originalprice_2)
    if 'bilety:' in originalprice_2:
        new_originalprice2 = originalprice_2.replace("bilety:","")
        listprices.append(new_originalprice2)
    elif 'Bilety:' in originalprice_2:
        new_originalprice2 = originalprice_2.replace("Bilety:","")
        listprices.append(new_originalprice2)
    else:
        listprices.append(originalprice_2)


    info_2 = container2.find('div', attrs={'class':'event_desc'}).text
    info2 = " ".join(re.split("\s+", info_2, flags=re.UNICODE))
    info3 = info2 + "\n"
    if "\'" in info2:
        new_info2 = info2.replace("\'", " ")
        listinfos.append(new_info2)
    elif "\"" in info2:
        new_info2 = info2.replace("\"", " ")
        listinfos.append(new_info2)
    else:
        listinfos.append(info2)
    print("Informacje: " + info3)

    print("")


#zapis w pętli do bazy danych

i=1;

cnxn = pyodbc.connect('Driver={SQL Server};Server=LAPTOP-3HJ4DJM0\SQLEXPRESS;Database=Test-Inzynierka;Trusted_Connection=yes;')
cursor = cnxn.cursor()
cursor.execute("DELETE FROM [EVENTS]")
cnxn.commit()
for name, date, place, price, category, info in zip(listnames, listdates, listplaces, listprices, listcategories, listinfos):
    cursor.execute("INSERT INTO [EVENTS] VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');".format(i, name, date, place,  price, category, info))
    cnxn.commit()
    i = i+1