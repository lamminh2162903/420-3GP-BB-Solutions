﻿using Utilitaires;
using System.Text;
using System.Xml;

namespace Contacts
{
    public class Contact :IXMLSerializable
    {
        private int numero;

        public String Nom
        {
            set;
            get;
        }

        public String Prenom
        {
            set;
            get;
        }

        public string NumeroCivique
        {
            set
            {
                numero = Int32.Parse(value);
            }

            get
            {
                return numero.ToString();
            }
        }

        public String Rue
        {
            set;
            get;
        }

        public String Description
        {
            set;
            get;
        }

        public Contact()
        {
            Nom = "";
            Prenom = "";
            numero = 0;
            Rue = "";
            Description = "";
        }

        public Contact(XmlElement elementContact)
        {
            FromXML(elementContact);
        }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{Nom}, {Prenom}");
            builder.AppendLine($"{NumeroCivique} {Rue}");
            builder.Append(Description);
            return builder.ToString();
        }

        /// <summary>
        /// On récupère les informations à partir de l'élément XML. La classe
        /// sait comment les données sont stockées dans l'élément XML
        /// </summary>
        /// 
        /// Exemple d'élément:
        /// 
        /// <contact nom="Simpson" prenom="Homer">
        ///     <adresse numero = "742" rue="Evergreen Terrace" />
        ///         <description> Homer Jay Simpson est le principal personnage fictif de la série télévisée 
        ///             d'animation Les Simpson et le père de la famille du même nom.
        ///         </description>
        /// </contact>
        /// 
        /// <param name="elem">L'élément XML</param>
        public void FromXML(XmlElement elem)
        {
            Nom = elem.GetAttribute("nom");
            Prenom = elem.GetAttribute("prenom");

            XmlElement adresse = elem["adresse"];
            NumeroCivique = adresse.GetAttribute("numero");
            Rue = adresse.GetAttribute("rue");

            XmlElement description = elem["description"];
            Description = description.InnerText.Trim();
        }

        /// <summary>
        /// Retourne un XMLElement qui représente l'objet. Remarquez le lien entre FromXML et ToXML
        /// </summary>
        /// <param name="doc">Le document pour créer l'élément</param>
        /// <returns>L'élément</returns>
        public XmlElement ToXML(XmlDocument doc)
        {
            XmlElement elementContact = doc.CreateElement("contact");
            elementContact.SetAttribute("nom", Nom);
            elementContact.SetAttribute("prenom", Prenom);

            XmlElement elementAdresse = doc.CreateElement("adresse");
            elementAdresse.SetAttribute("numero", NumeroCivique.ToString());
            elementAdresse.SetAttribute("rue", Rue);
            elementContact.AppendChild(elementAdresse);

            XmlElement elementDescription = doc.CreateElement("description");
            elementDescription.InnerText = Description;
            elementContact.AppendChild(elementDescription);

            return elementContact;
        }
    }
}